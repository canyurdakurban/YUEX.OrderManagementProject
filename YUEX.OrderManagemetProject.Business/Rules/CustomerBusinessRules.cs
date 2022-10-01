using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.Entities;
using YUEX.OrderManagementProject.Repository.Abstract;

namespace YUEX.OrderManagemetProject.Business.Rules
{
    public class CustomerBusinessRules
    {
        private ICustomerDAL _customerDAL;

        public CustomerBusinessRules(ICustomerDAL customerDAL = null)
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
