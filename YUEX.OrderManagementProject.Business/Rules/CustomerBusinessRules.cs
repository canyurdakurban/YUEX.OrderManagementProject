using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Repository.Abstract;

namespace YUEX.OrderManagementProject.Business.Rules
{
    public class CustomerBusinessRules
    {
        private ICustomerRepository _customerDAL;

        public CustomerBusinessRules(ICustomerRepository customerDAL = null)
        {
            _customerDAL = customerDAL;
        }

        public async Task<bool> CustomerNameCanNotDuplicated(string name)
        {
            Customer result = await _customerDAL.GetAsync(p => p.UserName == name);

            if (result != null)
            {
                return false;
            }

            return true;
        }
    }
}
