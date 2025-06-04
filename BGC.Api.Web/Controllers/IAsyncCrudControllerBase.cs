using Microsoft.AspNetCore.Mvc;

namespace BGC.Api.Web.Controllers
{
    public interface IAsyncCrudControllerBase<TEntity, TCreateEntity, TGetEntity>
    {
        Task<ActionResult<IEnumerable<TEntity>>> GetAll();
        Task<ActionResult<TEntity>> GetById(uint id);
        Task<ActionResult<TEntity>> Create(TCreateEntity entity);
        Task<ActionResult<TEntity>> Update(TEntity entity);
        Task<ActionResult<bool>> Delete(uint id);
    }
}
