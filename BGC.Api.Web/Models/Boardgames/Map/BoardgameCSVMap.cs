using CsvHelper.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BGC.Api.Web.Models.Boardgames.Map
{
    public class BoardgameCSVMap : ClassMap<Boardgame>
    {
        public BoardgameCSVMap()
        {
            Map(x => x.Name).Name("name");
            Map(x => x.YearPublished).Name("yearpublished");
            Map(x => x.IsExpansion).Name("is_expansion");
            Map(x => x.CreationTime).Constant(DateTime.Now);
            Map(x => x.Genre).Convert(x => GenreConverter(x.Row.Parser.Record!));
            Map(x => x.Collections).Ignore();
        }

        private static Genre GenreConverter(string[ ] input)
        {
            int genreEnumValue = 0;
            input = [ .. input.Skip(10) ];
            for (var count = 0; count <= 5; count++)
            {
                if (!input[ count ].IsNullOrEmpty())
                    genreEnumValue += (int)Enum.GetValues<Genre>()[ count ];
            }
            return (Genre)genreEnumValue;
        }
    }
}
