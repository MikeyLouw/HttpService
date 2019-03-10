using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpService.Interfaces
{
    public interface IHttpService
    {
        void SetupHttpClient(string baseAddress);
        Task<TResponse> GetAsync<TResponse>(string url, HttpRequestHeaders headers);
        Task<TResponse> PostAsync<TData, TResponse>(string url, TData data, HttpRequestHeaders headers);
        Task<TResponse> DeleteAsync<TResponse>(string url, HttpRequestHeaders headers);
    }
}
