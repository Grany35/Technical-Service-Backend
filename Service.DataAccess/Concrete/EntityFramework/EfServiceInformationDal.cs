using Microsoft.EntityFrameworkCore;
using Service.Core.DataAccess;
using Service.Core.Utilities.Pagination;
using Service.Core.Utilities.Params;
using Service.DataAccess.Abstract;
using Service.DataAccess.Concrete.EntityFramework.Context;
using Service.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataAccess.Concrete.EntityFramework
{
    public class EfServiceInformationDal : EfEntityBase<ServiceInformation, ContextDb>, IServiceInformationDal
    {
        public async Task<PagedList<ServiceInformation>> GetAllServicesAsync(ServiceInformationParams serviceParams)
        {
            using (var context = new ContextDb())
            {
                IQueryable<ServiceInformation> query = context.ServiceInformations.Include(x => x.Customer).Include(y => y.ReplacedParts).AsNoTracking().AsQueryable();

                if (serviceParams.IsActive != null)
                {
                    query = query.Where(x => x.Status == serviceParams.IsActive);
                }

                if (serviceParams.Query != null)
                {
                    serviceParams.Query = serviceParams.Query.ToLower();

                    query = query.Where(x =>
                    x.Customer.FullName.ToLower()
                    .Contains(serviceParams.Query)
                    ||
                    x.Customer.Email.ToLower()
                    .Contains(serviceParams.Query));
                }

                return await PagedList<ServiceInformation>.CreateAsync(query, serviceParams.PageNumber, serviceParams.PageSize);
            }
        }
    }
}
