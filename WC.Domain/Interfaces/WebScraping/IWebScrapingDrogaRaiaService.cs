using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Domain.DTO;

namespace WC.Domain.Interfaces.WebScraping
{
    public interface IWebScrapingDrogaRaiaService
    {
        Task<ProdutoDto> ExecutarWebScrapingDrogaRaiaAsync(RotaRamificadaDto rotaSementeDto);
    }
}
