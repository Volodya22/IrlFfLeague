using IrlFfLeague.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace IrlFfLeague.DataLayer
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Pick> Picks { get; set; }

        public DbSet<PlayerInPick> PlayerInPicks { get; set; }
    }
}
