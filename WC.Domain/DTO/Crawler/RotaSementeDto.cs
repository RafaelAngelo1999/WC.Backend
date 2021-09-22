﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Domain.DTO
{
    public class RotaSementeDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Url { get; set; }
        public string Pesquisa { get; set; }
        public List<RotaRamificadaDto> RotasRamificadas { get; set; }
        public DateTime Create_At { get; set; } = DateTime.Now;
        public DateTime Update_At { get; set; } = DateTime.Now;
    }
}
