using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Infra.Data.Entities
{
    [Table("Produtos")]
    public class ProdutoEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string SKU { get; set; }
        public float MediaAvaliacao { get; set; }
        public List<ImagemProdutoEntity> Imagens { get; set; }
        public DateTime Create_At { get; set; } = new DateTime();
        public DateTime Update_At { get; set; } = new DateTime();
    }
}