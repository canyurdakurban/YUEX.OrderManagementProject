using System.Collections.Generic;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Customer;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel.Product;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;

namespace YUEX.OrderManagementProject.Business.IService
{
    public interface IProductService
    {
        Task<ProductResponseModel> CreateProduct(ProductInsertRequestModel productRequest);
        Task<ProductResponseModel> UpdateProduct(ProductUpdateRequestModel productRequest);
        Task DeleteProduct(ProductDeleteRequestModel request);
        Task<ProductResponseModel> GetProductById(int id);
        Task<IList<ProductResponseModel>> GetAllProduct();
        IList<ProductResponseModel> SearchProduct(string searchText);

    }
}
