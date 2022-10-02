using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;
using YUEX.OrderManagementProject.Entities.Entities;

namespace YUEX.OrderManagementProject.Business.IService
{
    public interface ICustomerService
    {       
        Task<CustomerResponseModel> GetById(int id);
        Task<CustomerResponseModel> Add(CustomerRequestModel request);
        Task Delete(Customer request);
        Task<CustomerResponseModel> Update(CustomerRequestModel request);
        Task<IList<CustomerResponseModel>> GetAll();
        
    }
}
