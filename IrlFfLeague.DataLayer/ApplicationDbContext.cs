using IrlFfLeague.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace IrlFfLeague.DataLayer
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Data Source=DESKTOP-8F7A950\\SQLEXPRESS;Initial Catalog=IrlFfLeague;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Герберт"
                },
                new User
                {
                    Id = 2,
                    Name = "Роман"
                },
                new User
                {
                    Id = 3,
                    Name = "Артём"
                },
                new User
                {
                    Id = 4,
                    Name = "Владимир"
                },
                new User
                {
                    Id = 5,
                    Name = "Виктор"
                }
            );
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Pick> Picks { get; set; }

        public DbSet<PlayerInPick> PlayerInPicks { get; set; }
    }
}
