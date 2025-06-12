namespace BGC.Api.Web.Models.Boardgames
{
    [Flags]
    public enum Genre
    {
        Children = 1,
        Family = 2,
        Party = 4,
        Strategy = 8,
        Thematic = 16,
        WarGames = 32,
    }
}
