using BGC.Api.Web.Data;
using BGC.Api.Web.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;

namespace BGC.Api.Web.Controllers
{
    public abstract class AsyncCrudControllerBase<TEntity, TCreateEntity, TGetAllEntity>(BGCDbContext context) : ControllerBase,
        IAsyncCrudControllerBase<TEntity, TCreateEntity, TGetAllEntity>
        where TEntity : Entity
        where TCreateEntity : Entity
        where TGetAllEntity : Entity
    {
        public readonly BGCDbContext Context = context;

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TGetAllEntity>>> GetAll()
        {
            var entities = await Context.Set<TEntity>().ToListAsync();
            return Ok(entities);
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

        public TEntity MapToEntity<T>(T entity) => TinyMapper.Map<TEntity>(entity);
    }
}
