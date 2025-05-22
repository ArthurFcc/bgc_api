namespace BGC.Api.Web.Models.Boardgames;

[Flags]
public enum Genre
{
    Strategy = 1,
    Party = 2,
    Family = 4,
    Wargames = 8,
    Abstract = 16,
    Deckbuilding = 32,
    WorkerPlacement = 64,
    DungeonCrawlers = 128,
}