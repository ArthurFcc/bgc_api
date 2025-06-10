using BGC.Api.Web.Models.Boardgames;

namespace BGC.Api.Web.Models.Collections
{
    public class Collection : CollectionBase
    {
        public virtual IEnumerable<Boardgame> Boardgames { get; set; }

        /*
         * Future implementation of miniature collection
         * public IEnumerable<Miniature> Miniatures { get; set; }
        */
    }
}
