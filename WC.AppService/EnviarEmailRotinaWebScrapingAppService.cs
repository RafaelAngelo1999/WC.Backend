using System;
using System.Threading.Tasks;
using WC.AppService.Interfaces;
using WC.Domain.DTO;
using WC.Domain.Interfaces;
using WC.AppService.Base;

namespace WC.AppService
{
    public class EnviarEmailRotinaWebScrapingAppService : IEnviarEmailRotinaWebScrapingAppService
    {
        private readonly IEnvioEmailService _envioEmailService;
        private readonly IRotaRamificadaService _rotaRamificadaService;

        public EnviarEmailRotinaWebScrapingAppService(IRotaRamificadaService rotaRamificadaService, IEnvioEmailService envioEmailService)
        {
            this._rotaRamificadaService = rotaRamificadaService;
            this._envioEmailService = envioEmailService;
        }
        public async Task EnviarEmailRotinaWebScrapingAsync()
        {
            await _envioEmailService.EnviarEmailRotinaWebScrapingAsync().ConfigureAwait(false);
        }
    }
}
