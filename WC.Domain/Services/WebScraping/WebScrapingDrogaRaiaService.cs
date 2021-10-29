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
using WC.Domain.Interfaces.WebScraping;

namespace WC.Domain.Services
{
    public class WebScrapingDrogaRaiaService : IWebScrapingDrogaRaiaService
    {
        private readonly IHttpClientService _httpClient;
        protected HtmlDocument currentHtml = new HtmlDocument();

        public WebScrapingDrogaRaiaService(IHttpClientService httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ProdutoDto> ExecutarWebScrapingDrogaRaiaAsync(RotaRamificadaDto rotaSementeDto)
        {
            #region Comentario Mock
            //RotaSementeDto rotaSementeDto = new RotaSementeDto();
            //rotaSementeDto.Pesquisa = "Iphone 12 Pro Max";
            //rotaSementeDto.Url = "https://www.magazineluiza.com.br/iphone-12-pro-max/celulares-e-smartphones/s/te/12pm/";

            //RotaRamificadaDto rotaRamificadaDto = new RotaRamificadaDto();
            //rotaRamificadaDto.Url = "https://www.magazineluiza.com.br/iphone-12-pro-max-apple-128gb-azul-pacifico-67-cam-tripla-12mp-ios/p/155596200/te/12pm/";
            //rotaSementeDto.RotasRamificadas.Add(rotaRamificadaDto);

            //RotaRamificadaDto rotaRamificadaDto2 = new RotaRamificadaDto();
            //rotaRamificadaDto.Url = "https://www.magazineluiza.com.br/iphone-12-pro-max-apple-128gb-prateado-67-cam-tripla-12mp-ios/p/155596000/te/12pm/";
            //rotaSementeDto.RotasRamificadas.Add(rotaRamificadaDto2);

            //RotaRamificadaDto rotaRamificadaDto3 = new RotaRamificadaDto();
            //rotaRamificadaDto.Url = "https://www.magazineluiza.com.br/iphone-12-pro-max-apple-128gb-dourado-67-cam-tripla-12mp-ios/p/155596100/te/12pm/";
            //rotaSementeDto.RotasRamificadas.Add(rotaRamificadaDto3);

            //RotaRamificadaDto rotaRamificadaDto4 = new RotaRamificadaDto();
            //rotaRamificadaDto.Url = "https://www.magazineluiza.com.br/iphone-12-pro-max-apple-128gb-grafite-67-cam-tripla-12mp-ios/p/155595900/te/12pm/";
            //rotaSementeDto.RotasRamificadas.Add(rotaRamificadaDto4);
            #endregion

            ObterPagina(rotaSementeDto.Url).Wait();
            return ExtrairDados();
        }

        public async Task ObterPagina(string urlProduto)
        {
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36" },
                { "referer","https://www.havan.com.br/" }
            };

            var request = new RequestBuilder()
                .SetUrl(urlProduto)
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

        public ProdutoDto ExtrairDados()
        {
            string titulo = this.currentHtml.DocumentNode.SelectSingleNode("/html/body/div[9]/div/div[2]/div/div[4]/div[1]/div[2]/div/form/div[2]/div[2]/div/div[3]/div/div/label/div/div/span/span/span[2]").InnerText;
            string descricao = Filtros.FiltrarDescricaoHTML(this.currentHtml.DocumentNode.SelectSingleNode("/html/body/div[12]/div/div[4]/div/div[4]/div[1]/div[2]/div/form/div[7]/div/div[1]/div").InnerText);
            float preco = float.Parse(this.currentHtml.DocumentNode.SelectSingleNode("/html/body/div[12]/div/div[4]/div/div[4]/div[1]/div[2]/div/form/div[2]/div[2]/div/div[3]/div/div/label/div/div/span/p[1]/span[2]/text()").InnerText);
            float precoPromocional = float.Parse(this.currentHtml.DocumentNode.SelectSingleNode("/html/body/div[12]/div/div[4]/div/div[4]/div[1]/div[2]/div/form/div[2]/div[2]/div/div[3]/div/div/label/div/div/span/p[2]/span/span[2]").InnerText);
            float mediaAvaliacao = 5;
            string categoria = "Geladeiras";
            List<ImagemProdutoDto> imagens = ExtrairImagens();
            string sku = this.currentHtml.DocumentNode.SelectSingleNode("/html/body/div[12]/div/div[4]/div/div[4]/div[1]/div[2]/div/form/div[7]/div/div[2]/div/table/tbody/tr[2]/td").InnerText;
            var produtoDto = new ProdutoBuilder()
                .SetTitulo(titulo)
                .SetDescricao(descricao)
                .SetImagens(imagens)
                .SetSKU(sku)
                .SetCategoria(categoria)
                .SetMediaAvaliacao(mediaAvaliacao)
                .SetPreco(preco)
                .SetPrecoPromocional(precoPromocional)
                .Build();

            return produtoDto;
        }

        //AINDA NÃO TA FUNCIONANDO
        private List<ImagemProdutoDto> ExtrairImagens()
        {
            List<ImagemProdutoDto> images = new List<ImagemProdutoDto>();
            //var imagens = currentHtml.DocumentNode.SelectNodes("//img");

            //foreach (var imagem in imagens)
            //{
            //images.Add(new ImagemProdutoDto { Name = imagem.GetAttributeValue("alt", ""), Url = imagem.GetAttributeValue("src", "")});
            images.Add(new ImagemProdutoDto { Name = "Refrigerador 1 Porta 240L Cycle Defrost Electrolux RE31", Url = "https://www.havan.com.br/media/catalog/product/cache/9d7596cd5cb63ff070405d3cefaf1ace/r/e/refrigerador-240-litros-cycle-defrost-electrolux-re31_48728.jpg" });
            images.Add(new ImagemProdutoDto { Name = "Refrigerador 1 Porta 240L Cycle Defrost Electrolux RE31", Url = "https://www.havan.com.br/media/catalog/product/cache/9d7596cd5cb63ff070405d3cefaf1ace/r/e/refrigerador-240-litros-cycle-defrost-electrolux-re31_48732_6.jpg" });
            //}

            return images;
        }
    }
}
