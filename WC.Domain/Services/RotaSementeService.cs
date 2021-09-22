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
    public class RotaSementeService : IRotaSementeService
    {
        private readonly IRotaSementeRepository _rotaSementeRepository;
        private readonly IMapper _mapper;

        public RotaSementeService(IRotaSementeRepository rotaSementeRepository, IMapper mapper)
        {
            this._rotaSementeRepository = rotaSementeRepository;
            this._mapper = mapper;
        }

        public async Task<Guid> InserirRotaSementeAsync(RotaSementeDto rotaSementeDto)
        {
            Validate.That(rotaSementeDto.Url).IsNotNullOrWhiteSpace("MENSAGEM - Atributo URL Invalido");

            var rotaSementeEntity = _mapper.Map<RotaSementeEntity>(rotaSementeDto);

            return await _rotaSementeRepository.InserirRotaSementeAsync(rotaSementeEntity);

        }
    }
}
