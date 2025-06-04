using BGC.Api.Web.Data;
using BGC.Api.Web.Models.Boardgames;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;

namespace BGC.Api.Web.Controllers.Boardgames
{
    [ApiController]
    [Route("api/boardgame/[action]")]
    public class BoardgameController(IRepository<Boardgame> repository) 
        : AsyncCrudControllerBase<Boardgame>(repository)
    {
        [ExcludeFromApiReference]
        public override Task<ActionResult<bool>> Delete(uint id) => base.Delete(id);
        
    }
}
