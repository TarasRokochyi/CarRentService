using CarRentService.DAL.Models;
using CarRentService.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CarRentService.DAL.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly CarRentServiceContext context;
        protected readonly DbSet<TEntity> table;

        public GenericRepository(CarRentServiceContext context)
        {
            this.context = context;
            table = this.context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var added_entity = await table.AddAsync(entity);
            return added_entity.Entity;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await Task.Run(() => table.Remove(entity));
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await Task.Run(() => table.Remove(entity));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await Task.Run(() => table.Update(entity));
        }
    }
}
