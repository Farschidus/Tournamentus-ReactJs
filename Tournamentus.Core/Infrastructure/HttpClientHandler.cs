using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Tournamentus.Core.Infrastructure
{
    public class HttpClientHandler : IHttpHandler, IDisposable
    {
        private readonly HttpClient _client = new HttpClient();
        private bool _disposed;
        private AuthenticationHeaderValue _token;

        public AuthenticationHeaderValue Token
        {
            get
            {
                return _token;
            }
            set
            {
                _token = value;
                _client.DefaultRequestHeaders.Authorization = value;
            }
        }

        public Uri BaseAddress
        {
            get
            {
                return _client.BaseAddress;
            }

            set
            {
                if (!value.ToString().EndsWith("/"))
                {
                    value = new Uri($"{value.ToString()}/");
                }

                _client.BaseAddress = value;
            }
        }

        public HttpResponseMessage Delete(string url)
        {
            return DeleteAsync(url).Result;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await _client.DeleteAsync(url);
        }

        public HttpResponseMessage Get(string url)
        {
            return GetAsync(url).Result;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public HttpResponseMessage Patch(string url, HttpContent content)
        {
            return PatchAsync(url, content).Result;
        }

        public async Task<HttpResponseMessage> PatchAsync(string url, HttpContent content)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, url)
            {
                Content = content
            };

            HttpResponseMessage response = new HttpResponseMessage();

            return await _client.SendAsync(request);
        }

        public HttpResponseMessage Post(string url, HttpContent content)
        {
            return PostAsync(url, content).Result;
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return await _client.PostAsync(url, content);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _client.Dispose();
            }

            _disposed = true;
        }
    }
}
