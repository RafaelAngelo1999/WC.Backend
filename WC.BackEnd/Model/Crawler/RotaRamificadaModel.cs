using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.WebApi.Model
{
    public class RotaRamificadaModel
    {
        public EcommerceModel EcommerceId { get; set; }
        public MarcaModel MarcaId { get; set; }
        public string Url { get; set; }
        public bool WasScraping { get; set; }
    }
}
