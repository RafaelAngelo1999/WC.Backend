using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
