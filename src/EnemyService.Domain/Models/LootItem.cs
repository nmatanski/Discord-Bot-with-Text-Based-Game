
using ItemService.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnemyService.Domain.Models
{
    public class LootItem
    {
        [Key]
        public int ID { get; set; }

        public Item Item { get; set; }

        public int DropPercentage { get; set; }

        public bool IsDefaultItem { get; set; }


        [ForeignKey("Enemy")]
        public int EnemyID { get; set; }

        public virtual Enemy Enemy { get; set; }


        public LootItem(Item item, int dropPercentage, bool isDefaultItem)
        {
            Item = item;
            DropPercentage = dropPercentage;
            IsDefaultItem = isDefaultItem;
        }
    }
}