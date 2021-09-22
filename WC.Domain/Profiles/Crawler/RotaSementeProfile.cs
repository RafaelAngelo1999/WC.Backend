using AutoMapper;
using WC.Domain.DTO;
using WC.Infra.Data.Entities;

namespace WC.Domain.Profiles.Crawler
{
    public class RotaSementeProfile : Profile
    {
        public RotaSementeProfile()
        {
            CreateMap<RotaSementeDto, RotaSementeEntity>()
                .ReverseMap();
        }
    }
}