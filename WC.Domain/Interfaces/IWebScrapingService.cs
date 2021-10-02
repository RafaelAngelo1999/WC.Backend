
using System;
using System.Threading.Tasks;
using WC.Domain.DTO;

namespace WC.Domain.Interfaces
{
    public interface IWebScrapingService
    {
        ProdutoDto ExecutarWebScraping(RotaRamificadaDto rotaRamificadaDto);
    }
}
