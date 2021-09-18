using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.WebApi.Model
{
    public class ProdutoModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string SKU { get; set; }
        public float MediaAvaliacao { get; set; }
        public List<ImagemProdutoModel> Imagens { get; set; }
    }
}
