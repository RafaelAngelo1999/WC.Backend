using System;
using System.Threading.Tasks;
using WC.AppService.Interfaces;
using WC.Domain.DTO;
using WC.Domain.Interfaces;

namespace WC.AppService
{
    public class InserirProdutoAppService : IInserirProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public InserirProdutoAppService(IProdutoService produtoService)
        {
            this._produtoService = produtoService;
        }

        public async Task<Guid> InserirProdutoAsync(ProdutoDto produtoEntity)
        {
            return await _produtoService.InserirProdutoAsync(produtoEntity);
        }
    }
}
