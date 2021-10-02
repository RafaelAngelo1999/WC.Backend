using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WC.Infra.Data.Entities;

namespace WC.Infra.Data.Interfaces
{
    public interface IRotaRamificadaRepository
    {
        Task<IEnumerable<RotaRamificadaEntity>> ObterRotaRamificadaNotScrapingAsync();
        Task AtualizarRotaRamificadaAsync(Guid idRotaRamificada, RotaRamificadaEntity rotaRamificadaEntity);
        Task<RotaRamificadaEntity> ObterRotaRamificadaAsync(Guid id);
    }
}
