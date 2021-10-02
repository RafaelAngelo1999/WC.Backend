using AutoMapper;
using HtmlAgilityPack;
using System;
using System.Globalization;
using System.Threading.Tasks;
using WC.Domain.DTO;
using WC.Domain.Interfaces;
using WC.Infra.Data.Entities;
using WC.Infra.Data.Interfaces;
using WC.Shared.Exceptions;
using WC.Shared.Validacao;

namespace WC.Domain.Services
{
    public class WebCrawlerService : IWebCrawlerService
    {

        public WebCrawlerService()
        {
        }

        public async Task<RotaSementeDto> ExecutarWebCrawlerAsync (string nomeProduto)
        {
            RotaSementeDto rotaSementeDto = new RotaSementeDto();
            return rotaSementeDto;
        }
    }
}
