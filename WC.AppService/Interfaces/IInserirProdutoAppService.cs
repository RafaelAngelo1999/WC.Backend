using System;
using System.Threading.Tasks;
using WC.Domain.DTO;

namespace WC.AppService.Interfaces
{
    public interface IInserirProdutoAppService
    {
        Task<Guid> InserirProdutoAsync(ProdutoDto produto);
    }
}
