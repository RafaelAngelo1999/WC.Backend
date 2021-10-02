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
    public class WebScrapingService : IWebScrapingService
    {

        public WebScrapingService()
        {
        }

        public ProdutoDto ExecutarWebScraping(RotaRamificadaDto rotaRamificadaDto)
        {
            Validate.That(rotaRamificadaDto.Url).IsNotNullOrWhiteSpace("MENSAGEM - Atributo URL Invalido");

            var uri = new Uri(rotaRamificadaDto.Url);

            HtmlWeb web = new HtmlWeb();

            var doc = web.Load(rotaRamificadaDto.Url);

            var produto = new ProdutoDto
            {
                //Titulo = node.SelectSingleNode("td[1]").InnerText,
                //Descricao = node.SelectSingleNode("td[2]").InnerText,
                //Model = int.Parse(node.SelectSingleNode("td[3]").InnerText),
                //SKU = int.Parse(node.SelectSingleNode("td[3]").InnerText),
                //EstoqueQuantidade = int.Parse(node.SelectSingleNode("td[3]").InnerText),
                //MediaAvaliacao = int.Parse(node.SelectSingleNode("td[3]").InnerText),
                //PrecoPromocional = int.Parse(node.SelectSingleNode("td[3]").InnerText),
                //Preco = int.Parse(node.SelectSingleNode("td[3]").InnerText),
                //Age = int.Parse(node.SelectSingleNode("td[3]").InnerText)
            };

            return produto;

        }
    }
}
