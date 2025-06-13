using BGC.Api.Web.Controllers.AsyncCrudController;
using BGC.Api.Web.Controllers.Extensions;
using BGC.Api.Web.Data;
using BGC.Api.Web.Models.Collections;
using BGC.Api.Web.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Nelibur.ObjectMapper;

namespace BGC.Api.Web.Controllers.Collections
{
    [ApiController]
    [Route("api/collection/[action]")]
    public class CollectionController(BGCDbContext dbContext)
        : AsyncCrudController<Collection, CollectionBase, GetCollection>(dbContext)
    {
        public override IQueryable<Collection> CreateFilteredQuery(PagedRequest input)
        {
            return Context.Set<Collection>()
                .Include(x => x.Boardgames)
                .WhereIf(!input.SearchText.IsNullOrEmpty(), x => x.Title.Contains(input.SearchText!));
        }

        public override Task<ActionResult<Collection>> Create(CollectionBase entity)
        {
            TinyMapper.Bind<CollectionBase, Collection>();
            return base.Create(entity);
        }
    }
}
