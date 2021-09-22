using System;
using System.Threading.Tasks;
using WC.Infra.Data.Entities;

namespace WC.Infra.Data.Interfaces
{
    public interface IRotaSementeRepository
    {
        Task<Guid> InserirRotaSementeAsync(RotaSementeEntity rotaSementeEntity);
    }
}
