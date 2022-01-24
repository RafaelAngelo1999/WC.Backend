using AutoMapper;
using WC.Domain.DTO;
using WC.WebApi.Model;

namespace WC.WebApi.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<ProdutoDto, ProdutoModel>()
                .ReverseMap();
        }
    }
}
