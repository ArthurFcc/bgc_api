using BGC.Api.Web.Models.Boardgames;
using Microsoft.EntityFrameworkCore;

namespace BGC.Api.Web.Data;

public class BGCDbContext(DbContextOptions<BGCDbContext> options) : DbContext(options)
{
    public DbSet<Boardgame> Boardgames { get; set; }
}