using BGC.Api.Web.Models.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BGC.Api.Web.Controllers
{
    public class AsyncCrudControllerBase<TEntity>(IEnumerable<TEntity> entities) : ControllerBase
        where TEntity : Entity
    {
        /*
         * private readonly IRepository<TEntity> _repository;      
         */

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetById(uint id)
        {
            try
            {
                var result = entities.FirstOrDefault(x => x.Id == id);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw new Exception("Error getting entity", e);
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Create(TEntity entity)
        {
            try
            {
                entity.Id = entities.Max(x => x.Id) + 1;
                entity.CreationTime = DateTime.Now;

                var items = entities.Append(entity);
                return Ok(entity);
            }
            catch (Exception e)
            {
                throw new Exception("Error creating entity", e);
            }
        }

        [HttpPut]
        public virtual async Task<ActionResult<TEntity>> Update(TEntity entity)
        {
            var entityToUpdate = entities.FirstOrDefault(x => x.Id == entity.Id);



            return Ok();
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<bool>> Delete(uint id)
        {
            entities.Except([ entities.FirstOrDefault(x => x.Id == id) ]);

            return Ok(true);
        }
    }
}
