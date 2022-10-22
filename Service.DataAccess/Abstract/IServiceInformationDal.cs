using Service.Core.DataAccess;
using Service.Core.Utilities.Pagination;
using Service.Core.Utilities.Params;
using Service.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataAccess.Abstract
{
    public interface IServiceInformationDal : IEntityRepository<ServiceInformation>
    {
        Task<PagedList<ServiceInformation>> GetAllServicesAsync(ServiceInformationParams serviceParams);
    }
}
