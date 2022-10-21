using Service.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Business.Abstract
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
    }
}
