using System;
using System.Threading.Tasks;
using WC.AppService.Interfaces;
using WC.Domain.DTO;
using WC.Domain.Interfaces;
using WC.AppService.Base;

namespace WC.AppService
{
    public class ExecutarWebScrapingAppService : IExecutarWebScrapingAppService
    {
        private readonly IRotaRamificadaService _rotaRamificadaService;

        public ExecutarWebScrapingAppService(IRotaRamificadaService rotaRamificadaService)
        {
            this._rotaRamificadaService = rotaRamificadaService;
        }
        public async Task ExecutarWebScrapingAsync()
        {
            await _rotaRamificadaService.ExecutarWebScrapingAsync().ConfigureAwait(false);
        }
    }
}
