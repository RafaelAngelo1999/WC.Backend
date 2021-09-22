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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string SKU { get; set; }
        public float MediaAvaliacao { get; set; }
        public List<ImagemProdutoDto> Imagens { get; set; }
        public DateTime Create_At { get; set; } = DateTime.Now;
        public DateTime Update_At { get; set; } = DateTime.Now;
    }
}
