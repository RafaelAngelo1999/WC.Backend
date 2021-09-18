using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Infra.Data.Entities
{
    [Table("AvaliacoesProduto")]
    public class AvaliacaoProdutoEntity
    {
        [Required]
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int Estrela { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
    }
}