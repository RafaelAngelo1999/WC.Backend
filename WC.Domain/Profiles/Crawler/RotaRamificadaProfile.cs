using AutoMapper;
using WC.Domain.DTO;
using WC.Infra.Data.Entities;

namespace WC.Domain.Profiles.Crawler
{
    public class RotaRamificadaProfile : Profile
    {
        public RotaRamificadaProfile()
        {
            CreateMap<RotaRamificadaDto, RotaRamificadaEntity>()
                .ReverseMap();
        }
    }
}