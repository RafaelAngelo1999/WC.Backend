using AutoMapper;
using HtmlAgilityPack;
using System;
using System.Globalization;
using System.Threading.Tasks;
using WC.Domain.DTO;
using WC.Domain.Interfaces;
using WC.Domain.Interfaces.WebScraping;
using WC.Infra.Data.Entities;
using WC.Infra.Data.Interfaces;
using WC.Shared.Exceptions;
using WC.Shared.Util;
using WC.Shared.Validacao;

namespace WC.Domain.Services
{
    public class WebScrapingService : IWebScrapingService
    {

        private readonly IWebScrapingHavanService _webScrapingHavanService;
        private readonly IWebScrapingDrogaRaiaService _webScrapingDrogaRaiaService;

        public WebScrapingService(IWebScrapingHavanService webScrapingHavanService, IWebScrapingDrogaRaiaService webScrapingDrogaRaiaService)
        {
            this._webScrapingHavanService = webScrapingHavanService;
            this._webScrapingDrogaRaiaService = webScrapingDrogaRaiaService;
        }

        public async Task<ProdutoDto> ExecutarWebScraping(RotaRamificadaDto rotaRamificadaDto)
        {
            Validate.That(rotaRamificadaDto.Url).IsNotNullOrWhiteSpace("MENSAGEM - Atributo URL Invalido");

            //todo switch
            return await _webScrapingDrogaRaiaService.ExecutarWebScrapingDrogaRaiaAsync(rotaRamificadaDto);

            //return await _webScrapingHavanService.ExecutarWebScrapingHavanAsync(rotaRamificadaDto);


        }
    }
}
