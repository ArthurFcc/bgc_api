using BGC.Api.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BGC.Api.Web.Controllers;

public class AsyncCrudControllerBase<TEntity, TEntityIdType> : ControllerBase
    where TEntity : Entity<TEntityIdType>
{
    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TEntity>> Get(TEntityIdType id)
    {
        return Ok();
    }

    [HttpPost]
    public virtual async Task<ActionResult<TEntity>> Create(TEntity entity)
    {
        return Ok();
    }

    [HttpPut]
    public virtual async Task<ActionResult<TEntity>> Update(TEntity entity)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public virtual async Task<ActionResult<bool>> Delete(TEntityIdType id)
    {
        return Ok();
    }
}