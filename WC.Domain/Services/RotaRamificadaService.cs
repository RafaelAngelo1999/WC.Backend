using AutoMapper;
using HtmlAgilityPack;
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

        public async Task<List<RotaRamificadaDto>> ObterRotaRamificadaNotScrapingAsync()
        {
            var rotaRamificadaEntitys = await _rotaRamificadaRepository.ObterRotaRamificadaNotScrapingAsync();

            return _mapper.Map<IEnumerable<RotaRamificadaEntity>, List<RotaRamificadaDto>>(rotaRamificadaEntitys);
        }

        public async Task AtualizarRotaRamificadaAsync(RotaRamificadaDto rotaRamificadaDto)
        {
            var rotaRamificadaEntity = _mapper.Map<RotaRamificadaDto, RotaRamificadaEntity>(rotaRamificadaDto);

            await _rotaRamificadaRepository.AtualizarRotaRamificadaAsync(rotaRamificadaEntity.Id, rotaRamificadaEntity);
        }

    }
}
