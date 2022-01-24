using AutoMapper;
using HtmlAgilityPack;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WC.Domain.DTO;
using WC.Domain.Interfaces;
using WC.Infra.Data.Entities;
using WC.Infra.Data.Interfaces;
using WC.Shared.Exceptions;
using WC.Shared.Util;
using WC.Shared.Validacao;

namespace WC.Domain.Services
{
    public class WebCrawlerService : IWebCrawlerService
    {
        private readonly IWebCrawlerHavanService _webCrawlerHavanService;

        public WebCrawlerService(IWebCrawlerHavanService webCrawlerHavanService)
        {
            this._webCrawlerHavanService = webCrawlerHavanService;
        }

        public async Task<RotaSementeDto> ExecutarWebCrawlerAsync (string nomeProduto, Enums.Ecommercer ecommerce)
        {
            RotaSementeDto rotaSementeDto = new RotaSementeDto();
            return await _webCrawlerHavanService.ExecutarWebCrawlerHavanAsync(nomeProduto);


            //switch (ecommerce)
            //{
            //    case Enums.Ecommercer.MagazineLuiza:
            //        break;
            //    case Enums.Ecommercer.Amazon:
            //        // code block
            //        break;
            //    default:
            //        // code block
            //        break;
            //}

            //return rotaSementeDto;
        }
    }
}
