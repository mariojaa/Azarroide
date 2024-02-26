using AutoMapper;
using Azarroide.Application.DTOs;
using Azarroide.Domain.Entities;

namespace Azarroide.Infra.Data.Mapper
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<EmpresaEntitie, EmpresaEntitieDto>().ReverseMap();
            //CreateMap<EmpresaEntitieDto, EmpresaModelWeb>().ReverseMap();
        }
    }
}
