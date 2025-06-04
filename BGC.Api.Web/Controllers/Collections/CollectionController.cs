using BGC.Api.Web.Data;
using BGC.Api.Web.Models.Collections;
using Microsoft.AspNetCore.Mvc;

namespace BGC.Api.Web.Controllers.Collections
{
    [ApiController]
    [Route("api/collection/[action]")]
    public class CollectionController(IRepository<Collection> repository)
        : AsyncCrudControllerBase<Collection, CreateCollection, Collection>(repository)
    {
        public async Task AddBoardgamesToCollection(IEnumerable<BoardgameCollection> boardgames)
        {

        }
    }
}
