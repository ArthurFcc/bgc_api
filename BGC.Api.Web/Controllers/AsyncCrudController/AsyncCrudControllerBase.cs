using BGC.Api.Web.Data;
using BGC.Api.Web.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;

namespace BGC.Api.Web.Controllers.AsyncCrudController
{
    public abstract class AsyncCrudControllerBase<TEntity>(BGCDbContext context) : ControllerBase
        where TEntity : Entity
    {
        public readonly BGCDbContext Context = context;

        /// <summary>
        /// Should be called and build the query to filter the GetAll request
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [NonAction]
        public virtual IQueryable<TEntity> CreateFilteredQuery(PagedRequest input)
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        protected virtual IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query)
        {
            return query.OrderByDescending(e => e.Id);
        }

        protected virtual IQueryable<TEntity> ApplyPaging(IQueryable<TEntity> query, PagedRequest input)
        {
            return query.Take(input.MaxResultCount);
        }

        protected TEntity MapToEntity<TCreateEntity>(TCreateEntity entity) => TinyMapper.Map<TEntity>(entity);
    }
}
