using System;
using System.Threading.Tasks;
using WC.AppService.Interfaces;
using WC.Domain.DTO;
using WC.Domain.Interfaces;
using WC.AppService.Base;

namespace WC.AppService
{
    public class ExecutarWebCrawlerAppService : IExecutarWebCrawlerAppService
    {
        private readonly IRotaSementeService _rotaSementeService;
        private readonly IWebCrawlerService _webCrawlerService;


        public ExecutarWebCrawlerAppService(IRotaSementeService rotaSementeService, IWebCrawlerService webCrawlerService)
        {
            this._rotaSementeService = rotaSementeService;
            this._webCrawlerService = webCrawlerService;
        }
        public async Task<Guid> ExecutarWebCrawlerAsync(string nomeProduto)
        {
            var rotaSemente = await _webCrawlerService.ExecutarWebCrawlerAsync(nomeProduto).ConfigureAwait(false);

            return await _rotaSementeService.InserirRotaSementeAsync(rotaSemente);
        }
    }
}
