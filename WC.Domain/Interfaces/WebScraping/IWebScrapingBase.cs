using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Domain.DTO;

namespace WC.Domain.Interfaces.WebCrawler
{
    public interface IWebScrapingBase
    {
        Task ObterPagina(string urlProduto);
        ProdutoDto ExtrairDados();
    }
}
