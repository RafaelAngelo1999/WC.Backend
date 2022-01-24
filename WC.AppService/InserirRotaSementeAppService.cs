using System;
using System.Threading.Tasks;
using WC.AppService.Interfaces;
using WC.Domain.DTO;
using WC.Domain.Interfaces;

namespace WC.AppService
{
    public class InserirRotaSementeAppService : IInserirRotaSementeAppService
    {
        private readonly IRotaSementeService _rotaSementeService;

        public InserirRotaSementeAppService(IRotaSementeService rotaSementeService)
        {
            this._rotaSementeService = rotaSementeService;
        }

        public async Task<Guid> InserirRotaSementeAsync(RotaSementeDto rotaSementeDto)
        {
            return await _rotaSementeService.InserirRotaSementeAsync(rotaSementeDto);
        }
    }
}
