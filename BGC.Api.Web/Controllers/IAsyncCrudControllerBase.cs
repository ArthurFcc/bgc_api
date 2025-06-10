using BGC.Api.Web.Models.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BGC.Api.Web.Controllers
{
    public interface IAsyncCrudControllerBase<TEntity, TCreateEntity, TGetAllEntity>
        where TEntity : Entity
        where TGetAllEntity : Entity
        where TCreateEntity : Entity
    {
        Task<ActionResult<IEnumerable<TGetAllEntity>>> GetAll();
        Task<ActionResult<TEntity>> GetById(uint id);
        Task<ActionResult<TEntity>> Create(TCreateEntity entity);
        Task<ActionResult<TEntity>> Update(TEntity entity);
        Task<ActionResult<bool>> Delete(uint id);
    }
}
