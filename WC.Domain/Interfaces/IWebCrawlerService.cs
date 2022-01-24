
using System;
using System.Threading.Tasks;
using WC.Domain.DTO;
using WC.Shared.Util;

namespace WC.Domain.Interfaces
{
    public interface IWebCrawlerService
    {
        Task<RotaSementeDto> ExecutarWebCrawlerAsync(string nomeProduto, Enums.Ecommercer ecommerce);
    }
}
