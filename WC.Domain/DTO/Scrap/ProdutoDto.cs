using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Domain.DTO
{
    public class ProdutoDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string SKU { get; set; }
        public float EstoqueQuantidade { get; set; }
        public float MediaAvaliacao { get; set; }
        public float PrecoPromocional { get; set; }
        public float Preco { get; set; }
        public List<ImagemProdutoDto> Imagens { get; set; }
        public DateTime Create_At { get; set; } = DateTime.Now;
        public DateTime Update_At { get; set; } = DateTime.Now;

    }
}
