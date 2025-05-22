using BGC.Api.Web.Models.Boardgames;
using Microsoft.AspNetCore.Mvc;

namespace BGC.Api.Web.Controllers.Boardgames;

[ApiController]
[Route("api/boardgame")]
public class BoardgameController : AsyncCrudControllerBase<Boardgame, uint>
{
}