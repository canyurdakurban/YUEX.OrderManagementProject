using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Repository.Abstract;
using YUEX.OrderManagementProject.Business.IService;
using YUEX.OrderManagementProject.Business.Rules;

namespace YUEX.OrderManagementProject.Business.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerDAL;
        private readonly CustomerBusinessRules _businessRules;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerDAL, CustomerBusinessRules businessRules,IMapper mapper)
        {
            _customerDAL = customerDAL;
            _businessRules = businessRules;
            _mapper = mapper;
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
                Customer customerEntity = _mapper.Map<Customer>(request);
                customerEntity.IsActive = true;
                customerEntity = await _customerDAL.AddAsync(customerEntity);

                CustomerResponseModel customerResponce = _mapper.Map<CustomerResponseModel>(customerEntity);

                return customerResponce;
            }

        }
        
        public async Task Delete(CustomerDeleteModel request)
        {
            var result = await GetById(request.Id);
            result.IsActive = false;
            _customerDAL.Delete(_mapper.Map<Customer>(result));
        }

        public async Task<IList<CustomerResponseModel>> GetAll()
        {
            return _mapper.Map<IList<CustomerResponseModel>>(await _customerDAL.GetListAsync());
        }

        public async Task<CustomerResponseModel> GetById(int id)
        {
            return _mapper.Map<CustomerResponseModel>(await _customerDAL.GetAsync(x=>x.Id == id));
        }

        public async Task<CustomerResponseModel> Update(CustomerRequestModel request)
        {
            var result = await GetById(request.Id);

            Customer customerEntity = await _customerDAL.UpdateAsync(_mapper.Map<Customer>(result));
            CustomerResponseModel customerResponce = _mapper.Map<CustomerResponseModel>(customerEntity);

            return customerResponce;
        }
    }
}
