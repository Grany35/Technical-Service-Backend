using AutoMapper;
using Service.Business.Abstract;
using Service.DataAccess.Abstract;
using Service.Entities.Concrete;
using Service.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Business.Concrete
{
    public class ServiceInformationManager : IServiceInformationService
    {
        private readonly IServiceInformationDal _serviceInformationDal;
        private readonly IMapper _mapper;

        public ServiceInformationManager(IServiceInformationDal serviceInformationDal, IMapper mapper)
        {
            _serviceInformationDal = serviceInformationDal;
            _mapper = mapper;
        }

        public void AddService(CreateServiceDto createServiceDto)
        {
            ServiceInformation serviceInformation = _mapper.Map<ServiceInformation>(createServiceDto);

            _serviceInformationDal.Add(serviceInformation);
        }

        public void DeleteService(int serviceId)
        {
            var serviceInformation = _serviceInformationDal.Get(x => x.Id == serviceId);
            _serviceInformationDal.Delete(serviceInformation);
        }

        public async Task<List<ServiceInformation>> GetAllAsync()
        {
            var serviceInformations = await _serviceInformationDal.GetAllAsync();
            return serviceInformations;
        }
    }
}
