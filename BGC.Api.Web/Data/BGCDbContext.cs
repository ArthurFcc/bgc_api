using System.Collections.Generic;
using BGC.Api.Web.Models.Boardgames;
using BGC.Api.Web.Models.Collections;
using Microsoft.EntityFrameworkCore;

namespace BGC.Api.Web.Data
{
    public class BGCDbContext(DbContextOptions<BGCDbContext> options) : DbContext(options)
    {
        public DbSet<Boardgame> Boardgames { get; set; }
        public DbSet<Collection> Collections { get; set; }
    }
}
