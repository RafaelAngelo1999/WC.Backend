using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WC.WebApi.Model
{
    public class RotaSementeModel
    {
        public string Url { get; set; }
        public string Pesquisa { get; set; }
        public List<RotaRamificadaModel> RotasRamificadas { get; set; }
    }
}
