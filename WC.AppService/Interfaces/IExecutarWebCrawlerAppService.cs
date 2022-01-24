using System;
using System.Threading.Tasks;
using WC.Domain.DTO;
using WC.Shared.Util;

namespace WC.AppService.Interfaces
{
    public interface IExecutarWebCrawlerAppService
    {
        Task<Guid> ExecutarWebCrawlerAsync(string nomeProduto, Enums.Ecommercer ecommerce);
    }
}
