using System.ComponentModel.DataAnnotations;

namespace BGC.Api.Web.Models.Boardgames;

public class Boardgame : Entity<uint>
{
    public required string Name { get; set; }

    public required string Description { get; set; }
    
    [MaxLength(9999)]
    public ushort ReleaseYear { get; set; }

    public Genre Genre { get; set; }
}