
using ItemService.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerService.Domain.Models
{
    public class InventoryItem
    {
        [Key]
        public int ID { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public string Description { get => Quantity > 1 ? Item.NamePlural : Item.Name; }


        [ForeignKey("Player")]
        public int PlayerID { get; set; }

        public virtual Player Player { get; set; }


        public InventoryItem(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}