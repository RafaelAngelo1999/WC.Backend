using AutoMapper;
using WC.Domain.DTO;
using WC.WebApi.Model;

namespace WC.WebApi.Profiles
{
    public class RotaSementeProfile : Profile
    {
        public RotaSementeProfile()
        {
            CreateMap<RotaSementeDto, RotaSementeModel>()
                .ReverseMap();
        }
    }
}