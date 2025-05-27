
using BGC.Api.Web.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace BGC.Api.Web.Data
{
    public class Repository<TEntity>(BGCDbContext context) : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly BGCDbContext _context = context;

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(uint id)
            => await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            entity.CreationTime = DateTime.Now;
            var newEntity = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntity = _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();

            return updatedEntity.Entity;
        }

        public async Task<bool> DeleteAsync(uint id)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
