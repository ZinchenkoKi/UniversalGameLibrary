using AllGames.DataBase.Entity;
using Microsoft.EntityFrameworkCore;

namespace AllGames.DataBase
{
    internal class DataContext : DbContext
    {
        public DbSet<Games> Games { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AllGamesDB;Username=postgres;Password=1234567");
        }
    }
}
