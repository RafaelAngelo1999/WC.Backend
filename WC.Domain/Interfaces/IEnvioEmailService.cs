
using System;
using System.Threading.Tasks;
using WC.Domain.DTO;

namespace WC.Domain.Interfaces
{
    public interface IEnvioEmailService
    {
        Task EnviarEmailRotinaWebScrapingAsync();
    }
}
