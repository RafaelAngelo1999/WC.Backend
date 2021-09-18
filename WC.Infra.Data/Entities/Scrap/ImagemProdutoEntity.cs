using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Infra.Data.Entities
{
    [Table("ImagensProduto")]
    public class ImagemProdutoEntity
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
    }
}