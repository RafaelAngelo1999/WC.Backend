using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WC.Domain.DTO;

namespace WC.Domain.Builders
{
    public class RequestBuilder
    {
        private readonly RequestDto _request;
        public RequestBuilder()
        {
            _request = new RequestDto();
        }

        public RequestBuilder SetUrl(string url)
        {
            _request.Url = url;
            return this;
        }
        public RequestBuilder SetHeaders(Dictionary<string, string> headers)
        {
            _request.Headers = headers;
            return this;
        }
        public RequestBuilder SetCookies(CookieContainer cookies)
        {
            _request.Cookies = cookies;
            return this;
        }
        public RequestBuilder SetBody(Object body)
        {
            _request.Body = body;
            return this;
        }

        public RequestDto Build()
        {
            if (validate())
            {
                return _request;
            }
            else
            {
                //criar e lançar exceção personalizada, sugestão: "InvalidRequestException"
                throw new Exception();
            }
        }

        private bool validate()
        {
            return _request.Url != null;
        }
    }
}
