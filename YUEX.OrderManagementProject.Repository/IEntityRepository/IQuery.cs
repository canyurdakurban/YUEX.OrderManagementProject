using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YUEX.OrderManagementProject.Repository.IEntityRepository
{
    public interface IQuery<T>
    {
        IQueryable<T> Query();
    }
}
