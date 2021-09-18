using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
