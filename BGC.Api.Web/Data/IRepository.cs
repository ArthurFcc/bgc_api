using BGC.Api.Web.Models.Shared;

namespace BGC.Api.Web.Data
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(uint id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(uint id);
    }
}
