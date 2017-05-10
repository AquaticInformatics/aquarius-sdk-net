using System;
using Aquarius.TimeSeries.Client;
using ServiceStack;
using ServiceStack.Text;

namespace Aquarius.Samples.Client
{
    public interface ISamplesClient : IDisposable
    {
        IServiceClient Client { get; }
        AquariusServerVersion ServerVersion { get; }

        JsConfigScope WithScope();

        TResponse Get<TResponse>(IReturn<TResponse> requestDto);
        void Get(IReturnVoid requestDto);
        TResponse Post<TResponse>(IReturn<TResponse> requestDto);
        void Post(IReturnVoid requestDto);
        TResponse Put<TResponse>(IReturn<TResponse> requestDto);
        void Put(IReturnVoid requestDto);
        TResponse Delete<TResponse>(IReturn<TResponse> requestDto);
        void Delete(IReturnVoid requestDto);

        TResponse SparsePut<TResponse>(IReturn<TResponse> requestDto);
        void SparsePut(IReturnVoid requestDto);

        LazyResult<TDomainObject> LazyGet<TDomainObject, TRequest, TResponse>(TRequest requestDto)
            where TRequest : IPaginatedRequest, IReturn<TResponse>
            where TResponse : IPaginatedResponse<TDomainObject>;
    }
}
