using System.ComponentModel.DataAnnotations;

namespace Engine
{
    public class LootItem
    {
        [Key]
        public int ID { get; set; }

        public Item Item { get; set; }

        public int DropPercentage { get; set; }

        public bool IsDefaultItem { get; set; }


        public LootItem(Item item, int dropPercentage, bool isDefaultItem)
        {
            Item = item;
            DropPercentage = dropPercentage;
            IsDefaultItem = isDefaultItem;
        }
    }
}