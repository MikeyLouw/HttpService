using HttpService.Exceptions;
using HttpService.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpService.Implementation
{
    public class HttpService : IHttpService
    {
        private HttpClient _httpclient;
        public HttpService()
        {
            _httpclient = new HttpClient();
        }

        public void SetupHttpClient(string baseAddress)
        {
            _httpclient.BaseAddress = new Uri(baseAddress);
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string url, HttpRequestHeaders headers)
        {
            try
            {
                foreach (var header in headers)
                {
                    this._httpclient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                var result = await this._httpclient.DeleteAsync(url);
                var body = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(body);
            }
            catch (Exception ex)
            {
                throw new DeleteException(ex.Message, ex);
            }
        }

        public async Task<TResponse> GetAsync<TResponse>(string url, HttpRequestHeaders headers)
        {
            try
            {
                foreach (var header in headers)
                {
                    this._httpclient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }

                var result = await this._httpclient.GetAsync(url);
                var body = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(body);
            }
            catch (Exception ex)
            {
                throw new GetException(ex.Message, ex);
            }
        }

        public async Task<TResponse> PostAsync<TData, TResponse>(string url, TData data, HttpRequestHeaders headers)
        {
            try
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data));

                foreach (var header in headers)
                {
                    this._httpclient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    httpContent.Headers.Add(header.Key, header.Value);
                }

                var result = await this._httpclient.PostAsync(url, httpContent);
                var body = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(body);
            }
            catch (Exception ex)
            {
                throw new PostException(ex.Message, ex);
            }
        }
    }
}
