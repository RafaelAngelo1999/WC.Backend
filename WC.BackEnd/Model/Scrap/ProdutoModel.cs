using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.WebApi.Model
{
    public class ProdutoModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string SKU { get; set; }
        public float EstoqueQuantidade { get; set; }
        public int MediaAvaliacao { get; set; }
        public float PrecoPromocional { get; set; }
        public float Preco { get; set; }
        public List<ImagemProdutoModel> Imagens { get; set; }
    }
}
