using ItemService.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace ConsumableService.Domain.Models
{
    public class Consumable : Item
    {
        [Display(Name = "Amount to heal")]
        public int AmountToHeal { get; set; }


        public Consumable(int id, string name, string namePlural, int amountToHeal, int price) : base(id, name, namePlural, price)
        {
            AmountToHeal = amountToHeal;
        }
    }
}
