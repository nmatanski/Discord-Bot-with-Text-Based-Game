using ItemService.Domain.Models;

namespace ConsumableService.Domain.Models
{
    public class Consumable : Item
    {
        public int AmountToHeal { get; set; }


        public Consumable(int id, string name, string namePlural, int amountToHeal, int price) : base(id, name, namePlural, price)
        {
            AmountToHeal = amountToHeal;
        }
    }
}
