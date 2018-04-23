
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

        public DbSet<PlayerService.Domain.Models.Player> Players { get; set; }

        public DbSet<EnemyService.Domain.Models.Enemy> Enemies { get; set; }

        public DbSet<ItemService.Domain.Models.Item> Items { get; set; }

        public DbSet<LocationService.Domain.Models.Location> Locations { get; set; }

        public DbSet<QuestService.Domain.Models.Quest> Quests { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
