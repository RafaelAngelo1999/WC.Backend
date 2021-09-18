using System;
using System.Threading.Tasks;
using WC.Infra.Data.Entities;

namespace WC.Infra.Data.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Guid> InserirCotacaoAsync(ProdutoEntity produtoEntity);
    }
}
