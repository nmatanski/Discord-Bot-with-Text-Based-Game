using System.ComponentModel.DataAnnotations;

namespace ItemService.Domain.Models
{
    public abstract class Item
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string NamePlural { get; set; }

        public int Price { get; set; }


        public Item(int id, string name, string namePlural, int price)
        {
            ID = id;
            Name = name;
            NamePlural = namePlural;
            Price = price;
        }
    }
}