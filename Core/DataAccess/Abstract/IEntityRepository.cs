
using Entities.Concrete;
using Entities.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes);
        Task<List<TEntity>> GetAllPaginated<TKey>(int page, int size, Expression<Func<TEntity, TKey>> orderByDescending ,Expression<Func<TEntity, bool>> exp = null, params string[] includes);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp,params string[] includes);
        Task<TEntity> Get(params string[] includes);
        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> exp);
        Task<TEntity> CreateAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
    }
}
