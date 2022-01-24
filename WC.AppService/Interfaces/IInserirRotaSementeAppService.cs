using System;
using System.Threading.Tasks;
using WC.Domain.DTO;

namespace WC.AppService.Interfaces
{
    public interface IInserirRotaSementeAppService
    {
        Task<Guid> InserirRotaSementeAsync(RotaSementeDto rotaSementeDto);
    }
}
