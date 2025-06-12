using BGC.Api.Web.Models.Collections;
using BGC.Api.Web.Models.Shared;

namespace BGC.Api.Web.Models.Boardgames
{
    public class Boardgame : Entity
    {
        public required string Name { get; set; }
        public int YearPublished { get; set; }
        public Genre Genre { get; set; }
        public bool IsExpansion { get; set; }
        public virtual IEnumerable<Collection> Collections { get; set; }
    }
}
