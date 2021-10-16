using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.Domain.DTO;
using WC.Infra.Data.Entities;

namespace WC.Domain.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<ProdutoDto, ProdutoEntity>();

            CreateMap<ProdutoEntity, ProdutoDto>();
        }
    }
}
