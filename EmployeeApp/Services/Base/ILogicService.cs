using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeApp.Services.Base
{
    public interface ILogicService<TEntity>
    {
        Task<TEntity> GetByIdAsync(long id);

        Task<IQueryable<TEntity>> Query(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
