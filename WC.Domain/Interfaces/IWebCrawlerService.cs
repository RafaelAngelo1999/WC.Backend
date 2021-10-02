
using System;
using System.Threading.Tasks;
using WC.Domain.DTO;

namespace WC.Domain.Interfaces
{
    public interface IWebCrawlerService
    {
        Task<RotaSementeDto> ExecutarWebCrawlerAsync(string nomeProduto);
    }
}
