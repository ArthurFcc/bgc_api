using BGC.Api.Web.Data;
using BGC.Api.Web.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;
using Scalar.AspNetCore;

namespace BGC.Api.Web.Controllers
{
    public abstract class AsyncCrudControllerBase<TEntity, TCreateEntity, TGetEntity>(IRepository<TEntity> repository) : ControllerBase, 
        IAsyncCrudControllerBase<TEntity, TCreateEntity, TGetEntity>
        where TEntity : Entity
        where TCreateEntity : Entity
        where TGetEntity : Entity
    {
        private readonly IRepository<TEntity> _repository = repository;

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetById(uint id)
        {
            try
            {
                var result = _repository.GetAsync(id);
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
                var newEntity = await _repository.CreateAsync(mappedEntity);
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
            var updatedEntity = _repository.UpdateAsync(entity);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<bool>> Delete(uint id)
        {
            var result = await _repository.DeleteAsync(id);
            return Ok(result);
        }

        public TEntity MapToEntity<T>(T entity) => TinyMapper.Map<TEntity>(entity);
    }
}
