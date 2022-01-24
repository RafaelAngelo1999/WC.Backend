using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.WebApi.Model
{
    public class ProdutoModel
    {
        public Guid Id { get; set; }
        public RotaRamificadaModel RotaRamificadaId { get; set; }
        public EcommerceModel EcommerceId { get; set; }
        public MarcaModel MarcaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string SKU { get; set; }
        public string Marca { get; set; }
        public float MediaAvaliacao { get; set; }
        public float PrecoPromocional { get; set; }
        public float Preco { get; set; }
        public List<ImagemProdutoModel> Imagens { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
    }
}
