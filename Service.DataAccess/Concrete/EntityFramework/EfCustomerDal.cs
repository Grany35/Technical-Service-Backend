using Service.Core.DataAccess;
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
    public class EfCustomerDal : EfEntityBase<Customer, ContextDb>, ICustomerDal
    {
    }
}
