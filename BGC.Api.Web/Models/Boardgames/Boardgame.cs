using System.ComponentModel.DataAnnotations;
using BGC.Api.Web.Models.Collections;
using BGC.Api.Web.Models.Shared;

namespace BGC.Api.Web.Models.Boardgames
{
    public class Boardgame : Entity
    {
        [MaxLength(100)]
        public required string Title { get; set; }

        [MaxLength(1500)]
        public required string Description { get; set; }
        public ushort ReleaseYear { get; set; }
        public Genre Genre { get; set; }

        public virtual IEnumerable<Collection> Collections { get; set; }
    }
}
