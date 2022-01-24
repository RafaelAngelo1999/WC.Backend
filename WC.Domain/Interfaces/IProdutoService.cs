
using System;
using System.Threading.Tasks;
using WC.Domain.DTO;

namespace WC.Domain.Interfaces
{
    public interface IProdutoService
    {
        Task<Guid> InserirProdutoAsync(ProdutoDto produto);
    }
}
