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
        public WebCrawlerService()
        {
        }

        public async Task<RotaSementeDto> ExecutarWebCrawlerAsync (string nomeProduto, Enums.Ecommercer ecommerce)
        {
            RotaSementeDto rotaSementeDto = new RotaSementeDto();

            switch (ecommerce)
            {
                case Enums.Ecommercer.MagazineLuiza:
                    //rotaSementeDto =  await _webCrawlerMagazineLuizaService.ExecutarWebCrawlerMagazineLuizaAsync(nomeProduto);
                    break;
                case Enums.Ecommercer.Amazon:
                    // code block
                    break;
                default:
                    // code block
                    break;
            }

            return rotaSementeDto;
        }
    }
}
