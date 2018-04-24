using EnemyService.Domain.Models;
using ItemService.Domain.Models;
using QuestService.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocationService.Domain.Models
{
    public class Location
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Item ItemRequiredToEnter { get; set; }

        public Quest QuestAvailableHere { get; set; }

        public Enemy EnemyLivingHere { get; set; }

        public string Map { get; set; } // map image src


        [ForeignKey("LocationToNorth")]
        public int? LocationToNorthID { get; set; }

        public virtual Location LocationToNorth { get; set; }


        [ForeignKey("LocationToEast")]
        public int? LocationToEastID { get; set; }

        public Location LocationToEast { get; set; }


        [ForeignKey("LocationToSouth")]
        public int? LocationToSouthID { get; set; }

        public Location LocationToSouth { get; set; }


        [ForeignKey("LocationToWest")]
        public int? LocationToWestID { get; set; }

        public Location LocationToWest { get; set; }


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