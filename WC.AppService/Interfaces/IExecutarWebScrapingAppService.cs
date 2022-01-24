using System;
using System.Threading.Tasks;
using WC.Domain.DTO;

namespace WC.AppService.Interfaces
{
    public interface IExecutarWebScrapingAppService
    {
        Task ExecutarWebScrapingAsync();
    }
}
