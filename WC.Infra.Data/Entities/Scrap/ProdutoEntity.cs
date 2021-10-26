using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Infra.Data.Entities
{
    [Table("Produtos")]
    public class ProdutoEntity
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string SKU { get; set; }
        public float EstoqueQuantidade { get; set; }
        public int MediaAvaliacao { get; set; }
        public float PrecoPromocional { get; set; }
        public float Preco { get; set; }
        public List<ImagemProdutoEntity> Imagens { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
    }
}