using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WC.Domain.DTO
{
    public class RotaRamificadaDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Url { get; set; }
        public bool WasScraping { get; set; } = false;
        public DateTime Create_At { get; set; } = DateTime.Now;
        public DateTime Update_At { get; set; } = DateTime.Now;
    }
}
