using AutoMapper;
using Azarroide.Models;
using Azarroide.ViewModel;

namespace Azarroide.Mapper
{
    public class AutoMapperViewModel : Profile
    {
        public AutoMapperViewModel()
        {
            CreateMap<EmpresaModel, EmpresaViewModel>().ReverseMap();
        }
    }
}