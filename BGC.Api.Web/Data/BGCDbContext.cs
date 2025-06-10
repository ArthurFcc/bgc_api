using BGC.Api.Web.Models.Boardgames;
using BGC.Api.Web.Models.Collections;
using Microsoft.EntityFrameworkCore;

namespace BGC.Api.Web.Data
{
    public class BGCDbContext(DbContextOptions<BGCDbContext> options) : DbContext(options)
    {
        public DbSet<Boardgame> Boardgames { get; set; }
        public DbSet<Collection> Collections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BGC");

            modelBuilder.Entity<Collection>()
                .HasMany(x => x.Boardgames)
                .WithMany(x => x.Collections);

            base.OnModelCreating(modelBuilder);
        }
    }
}
