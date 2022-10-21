﻿using AutoMapper;
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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;

        public CustomerManager(ICustomerDal customerDal, IMapper mapper)
        {
            _customerDal = customerDal;
            _mapper = mapper;
        }

        public async Task<Customer> AddCustomerAsync(CustomerCreateDto customerCreateDto)
        {
            var checkCustomer = await _customerDal.GetAsync(x => x.Phone == customerCreateDto.Phone);
            if (checkCustomer != null)
            {
                return checkCustomer;
            }

            Customer customer=_mapper.Map<Customer>(customerCreateDto);

            _customerDal.Add(customer);

            return customer;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            var customers = await _customerDal.GetAllAsync();
            return customers;
        }
    }
}
