using BGC.Api.Web.Controllers.AsyncCrudController;
using BGC.Api.Web.Data;
using BGC.Api.Web.Models.Collections;
using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;

namespace BGC.Api.Web.Controllers.Collections
{
    [ApiController]
    [Route("api/collection/[action]")]
    public class CollectionController(BGCDbContext dbContext)
        : AsyncCrudController<Collection, CollectionBase, GetCollection>(dbContext)
    {
        public override Task<ActionResult<Collection>> Create(CollectionBase entity)
        {
            TinyMapper.Bind<CollectionBase, Collection>();
            return base.Create(entity);
        }
    }
}
