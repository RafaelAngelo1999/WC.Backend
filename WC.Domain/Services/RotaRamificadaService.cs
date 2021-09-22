using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WC.Domain.DTO;
using WC.Domain.Interfaces;
using WC.Infra.Data.Entities;
using WC.Infra.Data.Interfaces;
using WC.Shared.Exceptions;
using WC.Shared.Validacao;

namespace WC.Domain.Services
{
    public class RotaRamificadaService : IRotaRamificadaService
    {
        private readonly IRotaRamificadaRepository _rotaRamificadaRepository;
        private readonly IMapper _mapper;

        public RotaRamificadaService(IRotaRamificadaRepository rotaRamificadaRepository, IMapper mapper)
        {
            this._rotaRamificadaRepository = rotaRamificadaRepository;
            this._mapper = mapper;
        }

        public async Task ExecutarWebScrapingAsync()
        {
            //Validate.That(rotaRamificadaDto.Url).IsNotNullOrWhiteSpace("MENSAGEM - Atributo URL Invalido");

            //var rotaRamificadaDtoEntity = _mapper.Map<RotaSementeEntity>(rotaSementeDto);

            //var rotaRamificadaEntity = await _rotaRamificadaRepository.ObterRotaRamificadaNotScrapingAsync();

            //await ExecutarWebScrapingAsync(rotaRamificadaEntity);

        }

        public async Task ExecutarWebScrapingAsync(IEnumerable<RotaRamificadaEntity> rotaRamificadaEntity)
        {
            //if (rotaRamificadaEntity.Any())
            //{
            //    //ajuda lucão

            //}
        }
    }
}
