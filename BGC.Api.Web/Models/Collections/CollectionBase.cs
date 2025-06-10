using BGC.Api.Web.Models.Shared;

namespace BGC.Api.Web.Models.Collections
{
    public class CollectionBase : Entity
    {
        public byte[ ] Cover { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
