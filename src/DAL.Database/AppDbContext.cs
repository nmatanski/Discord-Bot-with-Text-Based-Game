
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

        public DbSet<EnemyService.Domain.Models.LootItem> LootItems { get; set; }

        public DbSet<WeaponService.Domain.Models.Weapon> Weapons { get; set; }

        public DbSet<ConsumableService.Domain.Models.Consumable> Consumables { get; set; }

        public DbSet<ItemService.Domain.Models.Item> Items { get; set; }

        public DbSet<LocationService.Domain.Models.Location> Locations { get; set; }

        public DbSet<QuestService.Domain.Models.Quest> Quests { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnemyService.Domain.Models.LootItem>()
                        .HasOne(l => l.Enemy)
                        .WithMany(e => e.LootTable)
                        .HasForeignKey(l => l.EnemyID);
        }

    }
}
