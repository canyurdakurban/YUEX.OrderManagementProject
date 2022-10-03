using System.Collections.Generic;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.DTOs.RequestModel;
using YUEX.OrderManagementProject.Entities.DTOs.ResponseModel;

namespace YUEX.OrderManagementProject.Business.IService
{
    public interface IProductService
    {
        Task<ProductResponseModel> CreateProduct(ProductRequestModel productRequest);
        Task<ProductResponseModel> UpdateProduct(ProductRequestModel productRequest);
        void DeleteProduct(int id);
        ProductResponseModel GetProductById(int id);
        IList<ProductResponseModel> GetAllProduct();
        IList<ProductResponseModel> SearchProduct(string searchText);

    }
}
