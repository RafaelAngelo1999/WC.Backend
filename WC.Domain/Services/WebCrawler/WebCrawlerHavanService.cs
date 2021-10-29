using AutoMapper;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using WC.Domain.Builders;
using WC.Domain.DTO;
using WC.Domain.Interfaces;
using WC.Domain.Interfaces.WebCrawler;
using WC.Infra.Data.Entities;
using WC.Infra.Data.Interfaces;
using WC.Shared.Exceptions;
using WC.Shared.Validacao;
using WC.Shared.Util;
using System.Net.Http;

namespace WC.Domain.Services
{
    public class WebCrawlerHavanService : IWebCrawlerHavanService
    {
        private readonly IHttpClientService _httpClient;
        protected HtmlDocument currentHtml = new HtmlDocument();

        public WebCrawlerHavanService(IHttpClientService httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<RotaSementeDto> ExecutarWebCrawlerHavanAsync(string nomeProduto)
        {
            RotaSementeDto rotaSementeDto = new RotaSementeDto { Url = "url.com.br", Pesquisa = "Pesquisa" };

            var uri = "https://www.havan.com.br/busca?q=geladeira%20electrolux";

            ObterPagina(uri.ToString()).Wait();

            var nodes = this.currentHtml.DocumentNode.SelectNodes("/html/body/div[1]/main/div[2]/div/div[4]/impulse-search//div/main/section/section[2]");
            foreach (var node in nodes)
            {
                var rotaRamificadaDto = new RotaRamificadaDto
                {
                    Url = node.SelectSingleNode("/a").InnerText,
                };

                rotaSementeDto.RotasRamificadas.Add(rotaRamificadaDto);
            }

            return rotaSementeDto;
        }
        public async Task ObterPagina(string urlPesquisa)
        {
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36" },
                { "referer","https://www.havan.com.br/" }
            };

            var request = new RequestBuilder()
                .SetUrl(urlPesquisa)
                .SetHeaders(headers)
                .Build();

            var response = await _httpClient.GetRequest(request);

            if (response.IsSuccessStatusCode)
            {
                currentHtml.LoadHtml(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Failed to get page. Website response " + response.StatusCode);
            }
        }

    }
}
