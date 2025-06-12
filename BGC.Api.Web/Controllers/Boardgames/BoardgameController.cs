using System.Globalization;
using BGC.Api.Web.Controllers.AsyncCrudController;
using BGC.Api.Web.Controllers.Extensions;
using BGC.Api.Web.Data;
using BGC.Api.Web.Models.Boardgames;
using BGC.Api.Web.Models.Boardgames.Map;
using BGC.Api.Web.Models.Shared;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

namespace BGC.Api.Web.Controllers.Boardgames
{
    [ApiController]
    [Route("api/boardgame/[action]")]
    public class BoardgameController(BGCDbContext dbContext)
        : AsyncCrudController<Boardgame, Boardgame, Boardgame>(dbContext)
    {
        [HttpGet]
        [ExcludeFromApiReference]
        public async Task<ActionResult<IEnumerable<Boardgame>>> SeedDatabase()
        {
            IEnumerable<Boardgame> boardgames = [ ];
            using (var reader = new StreamReader("C:/Users/yinso/Desktop/boardgames_ranks.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<BoardgameCSVMap>();
                boardgames = csv.GetRecords<Boardgame>().ToList();

                await Context.AddRangeAsync(boardgames);
                await Context.SaveChangesAsync();
            }

            return Ok(boardgames);
        }

        public override IQueryable<Boardgame> CreateFilteredQuery(PagedRequest input)
        {
            return Context.Set<Boardgame>()
                .WhereIf(!input.SearchText.IsNullOrEmpty(), x => x.Name.Contains(input.SearchText!));
        }

        [ExcludeFromApiReference]
        public override Task<ActionResult<bool>> Delete(uint id) => base.Delete(id);

    }
}
