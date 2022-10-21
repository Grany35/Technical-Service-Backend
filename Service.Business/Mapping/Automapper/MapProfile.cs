using AutoMapper;
using Service.Entities.Concrete;
using Service.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Business.Mapping.Automapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ServiceInformation, CreateServiceDto>().ReverseMap();

            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
        }
    }
}
