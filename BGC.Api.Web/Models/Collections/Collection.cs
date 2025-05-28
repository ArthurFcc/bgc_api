using BGC.Api.Web.Models.Boardgames;
using BGC.Api.Web.Models.Shared;

namespace BGC.Api.Web.Models.Collections
{
    public class Collection : Entity
    {
        public byte[] Cover { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public IEnumerable<Boardgame> Boardgames { get; set; }
        
        /*
         * Future implementation of miniature collection
         * public IEnumerable<Miniature> Miniatures { get; set; }
        */
    }
}
