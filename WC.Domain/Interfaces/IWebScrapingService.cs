
using System;
using System.Threading.Tasks;
using WC.Domain.DTO;
using WC.Shared.Util;

namespace WC.Domain.Interfaces
{
    public interface IWebScrapingService
    {
        Task<ProdutoDto> ExecutarWebScraping(RotaRamificadaDto rotaRamificadaDto);
    }
}
