using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WC.Domain.DTO;
using WC.Domain.Interfaces;

namespace WC.Domain.Services
{
    public class HttpClientService : IHttpClientService
    {
        protected HttpClient httpClient;
        public async Task<HttpResponseMessage> GetRequest(RequestDto request)
        {
            using (var handler = new HttpClientHandler())
            {
                if (request.Cookies != null)
                {
                    handler.CookieContainer = request.Cookies;
                }

                using (httpClient = new HttpClient(handler))
                {

                    foreach (var header in request.Headers)
                    {
                        httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
                    }

                    return await httpClient.GetAsync(request.Url);
                }
            }
        }

        public async Task<HttpResponseMessage> PostRequest(RequestDto request)
        {
            using (var handler = new HttpClientHandler())
            {
                if (request.Cookies != null)
                {
                    handler.CookieContainer = request.Cookies;
                }
                using (httpClient = new HttpClient(handler))
                {

                    foreach (var header in request.Headers)
                    {
                        httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
                    }


                    using (var body = new StringContent(request.Body.ToString()))
                    {
                        return await httpClient.PostAsync(request.Url, body);
                    }
                }
            }
        }
    }
}
