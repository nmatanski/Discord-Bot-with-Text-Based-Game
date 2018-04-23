using EnemyService.Domain.Models;
using ItemService.Domain.Models;
using QuestService.Domain.Models;

namespace LocationService.Domain.Models
{
    public class Location
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Item ItemRequiredToEnter { get; set; }

        public Quest QuestAvailableHere { get; set; }

        public Enemy EnemyLivingHere { get; set; }

        public Location LocationToNorth { get; set; }

        public Location LocationToEast { get; set; }

        public Location LocationToSouth { get; set; }

        public Location LocationToWest { get; set; }

        public string Map { get; set; } // map image src


        public Location(int id, string name, string description, string map, Item itemReqToEnter = null, Quest questAvailableHere = null, Enemy enemyLivingHere = null)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemRequiredToEnter = itemReqToEnter;
            QuestAvailableHere = questAvailableHere;
            EnemyLivingHere = enemyLivingHere;

            Map = map;
        }
    }
}