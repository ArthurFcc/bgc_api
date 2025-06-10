using BGC.Api.Web.Data;
using BGC.Api.Web.Models.Collections;
using Microsoft.AspNetCore.Mvc;

namespace BGC.Api.Web.Controllers.Collections
{
    [ApiController]
    [Route("api/collection/[action]")]
    public class CollectionController(BGCDbContext dbContext)
        : AsyncCrudControllerBase<Collection, CollectionBase, GetCollection>(dbContext)
    {
    }
}
