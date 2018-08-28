using IrlFfLeague.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace IrlFfLeague.DataLayer
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Club> Clubs { get; set; }

        DbSet<Player> Players { get; set; }

        DbSet<Pick> Picks { get; set; }

        DbSet<PlayerInPick> PlayerInPicks { get; set; }

        int SaveChanges();
    }
}
