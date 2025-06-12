using BGC.Api.Web.Models.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BGC.Api.Web.Controllers.AsyncCrudController
{
    public interface IAsyncCrudController<TEntity, TCreateEntity, TGetAllEntity>
        where TEntity : Entity
        where TGetAllEntity : Entity
        where TCreateEntity : Entity
    {
        ActionResult<PagedResult<TGetAllEntity>> GetAll(PagedRequest input);
        Task<ActionResult<TEntity>> GetById(uint id);
        Task<ActionResult<TEntity>> Create(TCreateEntity entity);
        Task<ActionResult<TEntity>> Update(TEntity entity);
        Task<ActionResult<bool>> Delete(uint id);
    }
}
