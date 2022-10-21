using Service.Business.Abstract;
using Service.DataAccess.Abstract;
using Service.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            var checkCustomer = await _customerDal.GetAsync(x => x.Phone == customer.Phone);
            if (checkCustomer != null)
            {
                throw new Exception("Zaten Bu kullanıcı kayıtlı. Lütfen servis giriş formuna gidiniz");
            }
            _customerDal.Add(customer);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var customers = await _customerDal.GetAllAsync();
            return customers;
        }
    }
}
