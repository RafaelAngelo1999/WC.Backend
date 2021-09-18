﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC.Infra.Data.Entities
{
    [Table("RotasSemente")]
    public class RotaSementeEntity
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string Pesquisa { get; set; }
        public List<RotaRamificadaEntity> Imagens { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Update_At { get; set; }
    }
}