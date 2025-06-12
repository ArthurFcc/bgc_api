using BGC.Api.Web.Data;
using BGC.Api.Web.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BGC.Api.Web.Controllers.AsyncCrudController
{
    public abstract class AsyncCrudController<TEntity, TCreateEntity, TGetAllEntity>(BGCDbContext context)
        : AsyncCrudControllerBase<TEntity>(context),
        IAsyncCrudController<TEntity, TCreateEntity, TGetAllEntity>
            where TEntity : Entity
            where TCreateEntity : Entity
            where TGetAllEntity : Entity
    {
        [HttpGet]
        public virtual ActionResult<PagedResult<TGetAllEntity>> GetAll([FromQuery] PagedRequest input)
        {
            var query = CreateFilteredQuery(input);

            var totalCount = query.Count();

            query = ApplySorting(query);
            query = ApplyPaging(query, input);

            var entities = query.ToList();

            return Ok(new PagedResult<TEntity>(totalCount, entities));
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetById(uint id)
        {
            try
            {
                var result = await Context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw new Exception("Error getting entity", e);
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Create(TCreateEntity entity)
        {
            try
            {
                var mappedEntity = MapToEntity(entity);
                mappedEntity.CreationTime = DateTime.Now;
                var newEntity = await Context.Set<TEntity>().AddAsync(mappedEntity);
                await Context.SaveChangesAsync();
                return Ok(newEntity);
            }
            catch (Exception e)
            {
                throw new Exception("Error creating entity", e);
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult<TEntity>> Update(TEntity entity)
        {
            entity.LastUpdateTime = DateTime.Now;
            var updatedEntity = Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<bool>> Delete(uint id)
        {
            var entity = await Context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                Context.Set<TEntity>().Remove(entity);
                Context.SaveChanges();
                return Ok(true);
            }
            return Problem("Entity not found to delete");
        }
    }
}
