using BGC.Api.Web.Models.Shared;

namespace BGC.Api.Web.Models.Collections
{
    public class CreateCollection : Entity
    {
        public byte[ ] Cover { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
