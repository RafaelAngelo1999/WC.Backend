using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WC.Domain.DTO;

namespace WC.Domain.Interfaces
{
    public interface IHttpClientService
    {
        public Task<HttpResponseMessage> GetRequest(RequestDto request);
        public Task<HttpResponseMessage> PostRequest(RequestDto request);

    }
}
