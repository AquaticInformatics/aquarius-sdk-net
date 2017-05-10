using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using Aquarius.Helpers;
using Aquarius.TimeSeries.Client;
using ServiceStack;
using ServiceStack.Logging;
using ServiceStack.Text;

namespace Aquarius.Samples.Client
{
    public class SamplesClient : ISamplesClient
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static ISamplesClient CreateConnectedClient(string baseUrl, string apiToken)
        {
            return new SamplesClient(baseUrl, apiToken);
        }

        public AquariusServerVersion ServerVersion { get; }

        private JsonServiceClient _client;

        private SamplesClient(string baseUrl, string apiToken)
        {
            _client = new SdkServiceClient(UriHelper.ResolveEndpoint(baseUrl, "/api", Uri.UriSchemeHttps));
            _client.Headers.Add("Authorization", $"token {apiToken}");

            ServerVersion = GetServerVersion();
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
            var scope = JsConfig.With(includeNullValues:includeNullValues, emitCamelCaseNames: true);
            return scope;
        }

        private AquariusServerVersion GetServerVersion()
        {
            var response = Get(new GetStatus());

            return AquariusServerVersion.Create(response.ReleaseName);
        }

        // TODO: This needs to be added to exposed Swagger methods
        [Route("/v1/status", HttpMethods.Get)]
        private class GetStatus : IReturn<StatusResponse>
        {
            
        }

        private class StatusResponse
        {
            public string ReleaseName { get; set; }
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


        public LazyResult<TDomainObject> LazyGet<TDomainObject, TRequest, TResponse>(TRequest requestDto)
            where TRequest : IPaginatedRequest, IReturn<TResponse>
            where TResponse : IPaginatedResponse<TDomainObject>
        {
            var responseDto = Get(requestDto);

            return new LazyResult<TDomainObject>
            {
                TotalCount = responseDto.TotalCount,
                DomainObjects = GetPaginatedResults<TDomainObject, TRequest, TResponse>(requestDto, responseDto)
            };
        }

        private IEnumerable<TDomainObject> GetPaginatedResults<TDomainObject, TRequest, TResponse>(TRequest requestDto, TResponse responseDto)
            where TRequest : IPaginatedRequest, IReturn<TResponse>
            where TResponse : IPaginatedResponse<TDomainObject>
        {
            var totalCount = responseDto.TotalCount;

            for (var count = 0; count < totalCount;)
            {
                foreach (var domainObject in responseDto.DomainObjects)
                {
                    yield return domainObject;
                }

                count += responseDto.DomainObjects.Count;

                if (count >= totalCount || !responseDto.DomainObjects.Any())
                    break;

                requestDto.Cursor = responseDto.Cursor;

                responseDto = Get(requestDto);
            }
        }

        private static TResponse InvokeWebServiceMethod<TResponse>(Func<TResponse> webServiceMethod, Func<JsConfigScope> scopeMethod = null)
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
                Log.Error(exception);
                throw;
            }
            catch (WebException exception)
            {
                Log.Error(exception);
                throw;
            }
        }


        private static void InvokeWebServiceMethod(Action webServiceMethod, Func<JsConfigScope> scopeMethod = null)
        {
            try
            {
                using (scopeMethod == null ? WithCommonScope() : scopeMethod.Invoke())
                {
                    webServiceMethod.Invoke();
                }
            }
            catch (WebServiceException exception)
            {
                Log.Error(exception);
                throw;
            }
            catch (WebException exception)
            {
                Log.Error(exception);
                throw;
            }
        }
    }
}
