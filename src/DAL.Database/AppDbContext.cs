
using Microsoft.EntityFrameworkCore;

namespace DAL.Database
{
    public class AppDbContext : DbContext
    {
        private string connection;

        public AppDbContext()
        {
            connection = DBConnections.GetAppHarborConnection();
            //connection = DBConnections.GetAzureConnection();
        }

        public DbSet<UserService.Domain.Models.User> Users { get; set; }

        public DbSet<Engine.PlayerService.Domain.Models.Player> Players { get; set; }

        public DbSet<Engine.Enemy> Enemies { get; set; }

        public DbSet<Engine.Item> Items { get; set; }

        public DbSet<Engine.Location> Locations { get; set; }

        public DbSet<Engine.Quest> Quests { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
