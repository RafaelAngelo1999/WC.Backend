using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Infra.Data.Entities
{
    [Table("Ecommerces")]
    public class EcommerceEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
    }
}