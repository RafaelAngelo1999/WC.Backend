
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WC.Domain.DTO;
using WC.Infra.Data.Entities;

namespace WC.Domain.Interfaces
{
    public interface IRotaRamificadaService
    {
        Task<List<RotaRamificadaDto>> ObterRotaRamificadaNotScrapingAsync();
        Task AtualizarRotaRamificadaAsync(RotaRamificadaDto rotaRamificadaDto);
    }
}
