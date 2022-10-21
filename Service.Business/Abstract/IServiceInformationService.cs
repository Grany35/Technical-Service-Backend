using Service.Entities.Concrete;
using Service.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Business.Abstract
{
    public interface IServiceInformationService
    {
        void AddService(CreateServiceDto createServiceDto);
        void DeleteService(int serviceId);
        Task<List<ServiceInformation>> GetAllAsync();
    }
}
