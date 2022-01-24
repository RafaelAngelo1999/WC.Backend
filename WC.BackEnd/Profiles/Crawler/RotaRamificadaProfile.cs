using AutoMapper;
using WC.Domain.DTO;
using WC.WebApi.Model;

namespace WC.WebApi.Profiles
{
    public class RotaRamificadaProfile : Profile
    {
        public RotaRamificadaProfile()
        {
            CreateMap<RotaRamificadaDto, RotaRamificadaModel>()
                .ReverseMap();
        }
    }
}