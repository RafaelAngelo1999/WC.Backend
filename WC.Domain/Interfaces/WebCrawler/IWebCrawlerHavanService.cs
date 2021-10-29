
using System;
using System.Threading.Tasks;
using WC.Domain.DTO;
using WC.Domain.Interfaces.WebCrawler;

namespace WC.Domain.Interfaces
{
    public interface IWebCrawlerHavanService
    {
        Task<RotaSementeDto> ExecutarWebCrawlerHavanAsync(string nomeProduto);
    }
}
