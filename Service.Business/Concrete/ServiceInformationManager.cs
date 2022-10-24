using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Service.Business.Abstract;
using Service.Core.Utilities.Pagination;
using Service.Core.Utilities.Params;
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

        public async Task AddService(CreateServiceDto createServiceDto)
        {
            ServiceInformation serviceInformation = _mapper.Map<ServiceInformation>(createServiceDto);

            await _serviceInformationDal.AddAsync(serviceInformation);
        }

        public async Task DeleteService(int serviceId)
        {
            var serviceInformation = await _serviceInformationDal.GetAsync(x => x.Id == serviceId);

            if (serviceInformation == null)
            {
                throw new Exception("Böyle bir servis kaydı yok!");
            }

            await _serviceInformationDal.DeleteAsync(serviceInformation);
        }

        public async Task<PagedList<ServiceInformation>> GetAllAsync(ServiceInformationParams serviceParams)
        {
            var source = await _serviceInformationDal.GetAllServicesAsync(serviceParams);

            return source;

        }
    }
}
