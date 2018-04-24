using EnemyService.Domain.Models;
using ItemService.Domain.Models;
using LocationService.Domain.Models;
using QuestCompletionItemService.Domain.Models;
using QuestService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using WeaponService.Domain.Models;

namespace DAL.Database.Helpers.InMemoryObjects
{
    public static class InitialWorldData
    {
        private static AppDbContext context = new AppDbContext();

        public static void Seed()
        {
            if (context.Items.Any()) return;
            foreach (var initialItems in PopulateItems())
            {
                context.Items.Add(initialItems);
            }

            if (context.Enemies.Any()) return;
            foreach (var initialEnemies in PopulateEnemies())
            {
                context.Enemies.Add(initialEnemies);
            }

            if (context.Quests.Any()) return;
            foreach (var initialQuests in PopulateQuests())
            {
                context.Quests.Add(initialQuests);
            }

            if (context.Locations.Any()) return;
            foreach (var initialLocations in PopulateLocations())
            {
                context.Locations.Add(initialLocations);
            }

            context.SaveChanges();
        }

        ///IDs
        ///_______________________

        // Weapons 1-299
        public const int ITEM_ID_SMALL_DAGGER = 1;

        // Armor 301-899

        // Consumables 901-999

        // Keys 1001-1199

        // Quest Items 1201-2999

        public const int QUEST_ID_TESTID = 1201;

        // Misc Items 3001-9999

        // Quests 10001-11499

        // Enemies 11501-15999

        public const int ENEMY_ID_DUMMY = 11501;

        // Locations 16001-19999

        public const int LOCATION_ID_HOME = 16001;
        public const int LOCATION_ID_TEST = 16002;

        // ??? 20001...

        ///_______________________

        private static List<Item> PopulateItems()
        {
            return new List<Item>()
            {
                new Weapon(ITEM_ID_SMALL_DAGGER, "Small Dagger", "Small Daggers", 0, 5, 20)
            };
        }
        private static List<Enemy> PopulateEnemies()
        {
            Enemy dummy = new Enemy(ENEMY_ID_DUMMY, "Dummy", 1, 4, 0, 45, 45);
            dummy.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SMALL_DAGGER), 100, false));


            return new List<Enemy>()
            {
                dummy
            };
        }

        private static List<Quest> PopulateQuests()
        {
            Quest testQuest = new Quest(
                QUEST_ID_TESTID,
                "Test Name",
                "Test Description",
                20, 30);

            testQuest.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SMALL_DAGGER), 1));
            testQuest.RewardItem = ItemByID(ITEM_ID_SMALL_DAGGER);


            return new List<Quest>()
            {
                testQuest
            };
        }

        private static List<Location> PopulateLocations()
        {
            Location home = new Location(LOCATION_ID_HOME, "Home", "Home", "img source?");

            Location testLocation = new Location(LOCATION_ID_TEST, "Test", "TestDescr", "test img source?");
            testLocation.QuestAvailableHere = QuestByID(QUEST_ID_TESTID);


            // Mapping

            home.LocationToNorth = testLocation;


            return new List<Location>()
            {
                home,
                testLocation
            };
        }


        public static Item ItemByID(int id)
        {
            foreach (Item item in context.Items)
                if (item.ID == id)
                    return item;
            return null;
        }

        public static Enemy EnemyByID(int id)
        {
            foreach (Enemy enemy in context.Enemies)
                if (enemy.ID == id)
                    return enemy;
            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in context.Quests)
                if (quest.ID == id)
                    return quest;
            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (Location location in context.Locations)
                if (location.ID == id)
                    return location;
            return null;
        }

    }
}
