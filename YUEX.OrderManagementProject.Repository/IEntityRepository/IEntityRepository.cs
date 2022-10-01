using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Repository.IEntityRepository
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetList(Expression<Func<T, bool>> predicate = null);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);

    }
}
