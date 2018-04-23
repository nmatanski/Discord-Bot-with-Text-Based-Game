
using System.ComponentModel.DataAnnotations;

namespace Engine
{
    public class InventoryItem
    {
        [Key]
        public int ID { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public string Description { get => Quantity > 1 ? Item.NamePlural : Item.Name; }


        public InventoryItem(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}