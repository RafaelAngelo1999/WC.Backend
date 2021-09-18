using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.WebApi.Model
{
    public class ImagemProdutoModel
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
