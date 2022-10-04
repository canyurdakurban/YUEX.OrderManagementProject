using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Customer;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;
using YUEX.OrderManagementProject.Entities.Entities;

namespace YUEX.OrderManagementProject.Business.IService
{
    public interface ICustomerService
    {       
        Task<CustomerResponseModel> GetById(int id);
        Task<CustomerResponseModel> Add(CustomerInsertRequestModel request);
        Task Delete(CustomerDeleteRequestModel request);
        Task<CustomerResponseModel> Update(CustomerUpdateRequestModel request);
        Task<IList<CustomerResponseModel>> GetAll();
        
    }
}
