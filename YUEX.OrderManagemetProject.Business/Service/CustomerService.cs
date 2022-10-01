using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Repository.Abstract;
using YUEX.OrderManagemetProject.Business.IService;
using YUEX.OrderManagemetProject.Business.Rules;

namespace YUEX.OrderManagemetProject.Business.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDAL _customerDAL;
        private readonly CustomerBusinessRules _businessRules;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerDAL customerDAL, CustomerBusinessRules businessRules)
        {
            _customerDAL = customerDAL;
            _businessRules = businessRules;
        }

        public async Task<CustomerResponseModel> Add(CustomerRequestModel request)
        {
            bool IsDuplicated = await _businessRules.CustomerNameCanNotDuplicated(request.UserName);

            if (!IsDuplicated)
            {
                throw new Exception();
            }
            else
            {
                Customer customer = _mapper.Map<Customer>(request);
                Customer customerEntity = await _customerDAL.AddAsync(customer);
                CustomerResponseModel customerResponce = _mapper.Map<CustomerResponseModel>(customerEntity);

                return customerResponce;
            }

        }

        public Task Delete(Customer request)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponseModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponseModel> Update(CustomerRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
