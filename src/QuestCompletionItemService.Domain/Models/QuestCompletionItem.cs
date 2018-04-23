using ItemService.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace QuestCompletionItemService.Domain.Models
{
    public class QuestCompletionItem
    {
        [Key]
        public int ID { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }


        public QuestCompletionItem(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}