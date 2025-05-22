namespace BGC.Api.Web.Models;

public class Entity<T>
{
    public required T Id { get; set; }
    public DateTime CreationTime { get; set; }
}