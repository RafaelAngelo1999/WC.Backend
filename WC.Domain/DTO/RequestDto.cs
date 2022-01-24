using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WC.Domain.DTO
{
    public class RequestDto
    {
        public string Url { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public CookieContainer Cookies { get; set; }
        public Object Body { get; set; }
    }
}
