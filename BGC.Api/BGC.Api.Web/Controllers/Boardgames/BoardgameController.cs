using BGC.Api.Web.Models.Boardgames;
using Microsoft.AspNetCore.Mvc;

namespace BGC.Api.Web.Controllers.Boardgames;

[ApiController]
[Route("api/boardgame/[action]")]
public class BoardgameController : AsyncCrudControllerBase<Boardgame>
{
    private static readonly IEnumerable<Boardgame> BoardGames = [
        new()
        {
            Id = 1,
            Name = "Massive Darkness 2",
            Description = "An amazing dungeon crawler",
            ReleaseYear = 2021,
            CreationTime = DateTime.Now,
            Genre = Genre.DungeonCrawlers
        },
        new()
        {
            Id = 2,
            Name = "Chtulhu: Death May Die",
            Description = "An amazing horror coop game",
            ReleaseYear = 2019,
            CreationTime = DateTime.Now,
            Genre = Genre.Strategy
        },
        new()
        {
            Id = 3,
            Name = "Coup",
            Description = "A game about deceiving",
            ReleaseYear = 2017,
            CreationTime = DateTime.Now,
            Genre = Genre.Party
        },
        new()
        {
            Id = 4,
            Name = "Monopoly",
            Description = "A financial crisis game",
            ReleaseYear = 2021,
            CreationTime = DateTime.Now,
            Genre = Genre.Family
        },
    ];
    
    public BoardgameController() : base(BoardGames)
    {
        
    }
}