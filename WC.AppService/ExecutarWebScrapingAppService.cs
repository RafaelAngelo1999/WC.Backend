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
        private readonly IWebScrapingService _webScrapingService;
        private readonly IProdutoService _produtoService;

        public ExecutarWebScrapingAppService(IRotaRamificadaService rotaRamificadaService, IWebScrapingService webScrapingService, IProdutoService produtoService)
        {
            this._rotaRamificadaService = rotaRamificadaService;
            this._webScrapingService = webScrapingService;
            this._produtoService = produtoService;
        }
        public async Task ExecutarWebScrapingAsync()
        {
            var rotaRamificadas = await _rotaRamificadaService.ObterRotaRamificadaNotScrapingAsync().ConfigureAwait(false);

            foreach (var rotaRamificada in rotaRamificadas)
            {
                var produtoDto = await _webScrapingService.ExecutarWebScraping(rotaRamificada);

                await _produtoService.InserirProdutoAsync(produtoDto);

                await _rotaRamificadaService.AtualizarRotaRamificadaAsync(rotaRamificada);
            }
        }
    }
}
