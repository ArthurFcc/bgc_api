using BGC.Api.Web.Data;
using BGC.Api.Web.Models.Boardgames;
using Microsoft.AspNetCore.Mvc;

namespace BGC.Api.Web.Controllers.Boardgames
{
    [ApiController]
    [Route("api/boardgame/[action]")]
    public class BoardgameController(IRepository<Boardgame> repository) 
        : AsyncCrudControllerBase<Boardgame>(repository)
    {
    }
}
