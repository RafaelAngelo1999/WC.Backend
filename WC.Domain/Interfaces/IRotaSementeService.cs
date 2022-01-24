
using System;
using System.Threading.Tasks;
using WC.Domain.DTO;

namespace WC.Domain.Interfaces
{
    public interface IRotaSementeService
    {
        Task<Guid> InserirRotaSementeAsync(RotaSementeDto rotaSementeDto);
    }
}
