using AutoMapper;
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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            this._produtoRepository = produtoRepository;
            this._mapper = mapper;
        }

        public async Task<Guid> InserirProdutoAsync(ProdutoDto produtoDto)
        {
            Validate.That(produtoDto.Titulo).IsNotNullOrWhiteSpace("MENSAGEM - Atributo Nome Invalido");

            var produtoEntity = _mapper.Map<ProdutoEntity>(produtoDto);

            return await _produtoRepository.InserirProdutoAsync(produtoEntity);

        }
    }
}
