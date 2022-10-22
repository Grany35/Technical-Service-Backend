using Service.Core.Utilities.Pagination;
using Service.Core.Utilities.Params;
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
        Task AddService(CreateServiceDto createServiceDto);
        Task DeleteService(int serviceId);
        Task<PagedList<ServiceInformation>> GetAllAsync(ServiceInformationParams serviceParams);
    }
}
