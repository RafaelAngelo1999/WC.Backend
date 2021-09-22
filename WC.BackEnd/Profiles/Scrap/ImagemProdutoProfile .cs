using AutoMapper;
using WC.Domain.DTO;
using WC.WebApi.Model;

namespace WC.WebApi.Profiles
{
    public class ImagemProdutoProfile : Profile
    {
        public ImagemProdutoProfile()
        {
            CreateMap<ImagemProdutoDto, ImagemProdutoModel>()
                .ReverseMap();
        }
    }
}
