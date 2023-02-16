using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using Aquarius.Helpers;
using Aquarius.Samples.Client.ServiceModel;
using Aquarius.TimeSeries.Client;
using ServiceStack;
using ServiceStack.Logging;
using ServiceStack.Text;

namespace Aquarius.Samples.Client
{
    public class SamplesClient : ISamplesClient
    {
        public const string AuthorizationHeaderKey = HttpHeaders.Authorization;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly object SyncLock = new object();

        private static bool _serviceStackConfigured;

        private static void SetupServiceStack()
        {
            if (_serviceStackConfigured)
                return;

            lock (SyncLock)
            {
                if (_serviceStackConfigured)
                    return;

                ServiceStackConfig.ConfigureServiceStack();

                _serviceStackConfigured = true;
            }
        }


        public static ISamplesClient CreateConnectedClient(string baseUrl, string apiToken)
        {
            return new SamplesClient(baseUrl, apiToken);
        }

        public static ISamplesClient CreateTestClient(IServiceClient client)
        {
            return new SamplesClient(client, string.Empty);
        }

        public AquariusServerVersion ServerVersion { get; }

        public UserProfile AuthenticatedUser { get; }

        public string LocationResponseHeader { get; private set; }

        private IServiceClient _client;

        private SamplesClient(string baseUrl, string apiToken)
            :this(new SamplesServiceClient(UriHelper.ResolveEndpoint(baseUrl, "/api", Uri.UriSchemeHttps)), apiToken)
        {
        }

        private SamplesClient(IServiceClient client, string apiToken)
        {
            SetupServiceStack();

            _client = client;

            if (_client is SamplesServiceClient ssc)
            {
                ssc.ResultsFilterResponse = (response, o, method, uri, request) =>
                    LocationResponseHeader = response.Headers[HttpResponseHeader.Location];
            }

            Client.AddHeader(AuthorizationHeaderKey, $"token {apiToken}");

            ServerVersion = GetServerVersion();
            AuthenticatedUser = GetAuthenticatedUser();

            Log.Info($"Connected to {GetBaseUri()} ({ServerVersion}) as {AuthenticatedUser.FullName}");
        }

        private string GetBaseUri()
        {
            return (Client as JsonServiceClient)?.BaseUri ?? "http://fake.aqsamples.com/api";
        }

        public IServiceClient Client => _client;

        public void Dispose()
        {
            _client?.Dispose();
            _client = null;
        }

        public JsConfigScope WithScope()
        {
            return WithCommonScope();
        }

        private static JsConfigScope WithCommonScope()
        {
            return WithScope(includeNullValues: false);
        }

        private static JsConfigScope WithSparsePutScope()
        {
            return WithScope(includeNullValues: true);
        }

        private static JsConfigScope WithScope(bool includeNullValues)
        {
            var scope = JsConfig.With(new Config
            {
                IncludeNullValues = includeNullValues,
                TextCase = TextCase.CamelCase
            });

            return scope;
        }

        private AquariusServerVersion GetServerVersion()
        {
            var response = Get(new GetStatus());

            return AquariusServerVersion.Create(response.ReleaseName);
        }

        private UserProfile GetAuthenticatedUser()
        {
            return Get(new GetUserTokens())
                .User
                .UserProfile;
        }

        // TODO: The authenticated user request & response DTOs need to be added to the exposed Swagger methods
        [Route("/v1/usertokens")]
        internal class GetUserTokens : IReturn<UserTokensResponse>
        {
        }

        internal class UserTokensResponse
        {
            public User User { get; set; }
        }

        public TResponse Get<TResponse>(IReturn<TResponse> requestDto)
        {
            return InvokeWebServiceMethod(() => _client.Get(requestDto));
        }

        public void Get(IReturnVoid requestDto)
        {
            InvokeWebServiceMethod(() => _client.Get(requestDto));
        }

        public TResponse Post<TResponse>(IReturn<TResponse> requestDto)
        {
            return InvokeWebServiceMethod(() => _client.Post(requestDto));
        }

        public void Post(IReturnVoid requestDto)
        {
            InvokeWebServiceMethod(() => _client.Post(requestDto));
        }

        public TResponse Post<TResponse>(string relativeOrAbsoluteUri, object request)
        {
            return InvokeWebServiceMethod(() => _client.Post<TResponse>(relativeOrAbsoluteUri, request));
        }

        public TResponse Put<TResponse>(IReturn<TResponse> requestDto)
        {
            return InvokeWebServiceMethod(() => _client.Put(requestDto));
        }

        public void Put(IReturnVoid requestDto)
        {
            InvokeWebServiceMethod(() => _client.Put(requestDto));
        }

        public TResponse Delete<TResponse>(IReturn<TResponse> requestDto)
        {
            return InvokeWebServiceMethod(() => _client.Delete(requestDto));
        }

        public void Delete(IReturnVoid requestDto)
        {
            InvokeWebServiceMethod(() => _client.Delete(requestDto));
        }

        public TResponse SparsePut<TResponse>(IReturn<TResponse> requestDto)
        {
            return InvokeWebServiceMethod(() => _client.Put(requestDto), WithSparsePutScope);
        }

        public void SparsePut(IReturnVoid requestDto)
        {
            InvokeWebServiceMethod(() => _client.Put(requestDto), WithSparsePutScope);
        }


        public void PostFileWithRequest<TRequest>(
            string path,
            TRequest requestDto,
            HttpContent extraContent = null,
            string extraContentName = null) where TRequest : IReturnVoid
        {
            var fileToUpload = new FileInfo(path);

            using (var stream = fileToUpload.OpenRead())
            {
                PostFileWithRequest(stream, fileToUpload.Name, requestDto, extraContent, extraContentName);
            }
        }

        public TResponse PostFileWithRequest<TResponse>(
            string path,
            IReturn<TResponse> requestDto,
            HttpContent extraContent = null,
            string extraContentName = null)
        {
            var fileToUpload = new FileInfo(path);

            using (var stream = fileToUpload.OpenRead())
            {
                return PostFileWithRequest(stream, fileToUpload.Name, requestDto, extraContent, extraContentName);
            }
        }

        public void PostFileWithRequest<TRequest>(
            Stream contentToUpload,
            string uploadedFileName,
            TRequest requestDto,
            HttpContent extraContent = null,
            string extraContentName = null) where TRequest : IReturnVoid
        {
            var fileUploader = FileUploader.Create(_client);

            InvokeWebServiceMethod(() => fileUploader.PostFileWithRequest(
                GetPostUrl(requestDto),
                contentToUpload,
                uploadedFileName,
                requestDto,
                extraContent,
                extraContentName));

            LocationResponseHeader = fileUploader.LocationResponseHeader;
        }

        public TResponse PostFileWithRequest<TResponse>(
            Stream contentToUpload,
            string uploadedFileName,
            IReturn<TResponse> requestDto,
            HttpContent extraContent = null,
            string extraContentName = null)
        {
            var fileUploader = FileUploader.Create(_client);

            var response = InvokeWebServiceMethod(() => fileUploader.PostFileWithRequest(
                GetPostUrl(requestDto),
                contentToUpload,
                uploadedFileName,
                requestDto,
                extraContent,
                extraContentName));

            LocationResponseHeader = fileUploader.LocationResponseHeader;

            return response;
        }

        private string GetPostUrl(object requestDto)
        {
            if (_client is JsonServiceClient jsonServiceClient)
                return jsonServiceClient.ResolveTypedUrl(HttpMethods.Post, requestDto);

            return requestDto.ToPostUrl();
        }

        public LazyResult<TDomainObject> LazyGet<TDomainObject, TRequest, TResponse>(TRequest requestDto, CancellationToken? cancellationToken = null, IProgressReporter progressReporter = null)
            where TRequest : IPaginatedRequest, IReturn<TResponse>
            where TResponse : IPaginatedResponse<TDomainObject>

        {
            progressReporter?.Started();

            var responseDto = Get(requestDto);

            return new LazyResult<TDomainObject>
            {
                TotalCount = responseDto.TotalCount,
                DomainObjects = GetPaginatedResults<TDomainObject, TRequest, TResponse>(requestDto, responseDto, cancellationToken, progressReporter)
            };
        }

        private IEnumerable<TDomainObject> GetPaginatedResults<TDomainObject, TRequest, TResponse>(TRequest requestDto, TResponse responseDto, CancellationToken? cancellationToken, IProgressReporter progressReporter)
            where TRequest : IPaginatedRequest, IReturn<TResponse>
            where TResponse : IPaginatedResponse<TDomainObject>
        {
            var totalCount = responseDto.TotalCount;

            for (var count = 0; count < totalCount;)
            {
                if (responseDto.DomainObjects == null)
                    break;

                if (cancellationToken.HasValue && cancellationToken.Value.IsCancellationRequested)
                    break;

                foreach (var domainObject in responseDto.DomainObjects)
                {
                    yield return domainObject;
                }

                count += responseDto.DomainObjects.Count;

                progressReporter?.Progress(count, totalCount);

                if (count >= totalCount || count >= responseDto.TotalCount || !responseDto.DomainObjects.Any() || string.IsNullOrEmpty(responseDto.Cursor))
                    break;

                requestDto.Cursor = responseDto.Cursor;

                responseDto = Get(requestDto);
            }

            progressReporter?.Completed();
        }

        public void InvokeWebServiceMethod(Action webServiceMethod, Func<JsConfigScope> scopeMethod = null)
        {
            const int dummyValueToIgnore = 0;

            var unused = InvokeWebServiceMethod(() =>
            {
                webServiceMethod.Invoke();

                return dummyValueToIgnore;
            }, scopeMethod);
        }

        public TResponse InvokeWebServiceMethod<TResponse>(Func<TResponse> webServiceMethod,
            Func<JsConfigScope> scopeMethod = null)
        {
            try
            {
                using (scopeMethod == null ? WithCommonScope() : scopeMethod.Invoke())
                {
                    return webServiceMethod.Invoke();
                }
            }
            catch (WebServiceException exception)
            {
                if (exception.IsAny500() && IsStatusRequest(webServiceMethod))
                {
                    throw new SamplesMaintenanceModeException($"{exception.Message}: AQUARIUS Samples is in maintenance mode", exception);
                }
                if (exception.IsAny500())
                {
                    InvokeWebServiceMethod(() => _client.Get(new GetStatus()));
                }
                throw WebServiceExceptionHandler.CreateSamplesApiExceptionFromResponse(exception);
            }
            catch (WebException exception)
            {
                throw WebServiceExceptionHandler.CreateSamplesApiExceptionFromResponse(exception);
            }
        }
        
        private static bool IsStatusRequest<TResponse>(Func<TResponse> webServiceMethod)
        {
            return webServiceMethod.Method.ReturnType == typeof(Status);
        }
    }
}
