using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.Concrete
{
    public class EntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : IdentityDbContext<AppUser>
    {
        private readonly TContext _context;

        public EntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            _context.SaveChanges();
            return entity;
        } 


        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            if(exp!=null) query = query.Where(exp);

            return await query.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllPaginated<TKey>(int page, int size, Expression<Func<TEntity, TKey>> orderByDescending, Expression<Func<TEntity, bool>> exp = null, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>()
                .OrderByDescending(orderByDescending);
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return exp is null
                ? await query.Skip((page-1)*size).Take(size).ToListAsync()
                : await query.Where(exp).Skip((page-1)*size).Take(size).ToListAsync();


        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return exp == null ? await query.FirstOrDefaultAsync() : await query.Where(exp).FirstOrDefaultAsync();
        }

        public async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> exp)
        {
            return await _context.Set<TEntity>().AnyAsync(exp);
        }

		public async Task<TEntity> Get(params string[] includes)
		{
			IQueryable<TEntity> query = _context.Set<TEntity>();
			if (includes != null)
			{
				foreach (var item in includes)
				{

					query = query.Include(item);
				}
			}
			return await query.FirstOrDefaultAsync();
		}

		public void UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
        public void DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
