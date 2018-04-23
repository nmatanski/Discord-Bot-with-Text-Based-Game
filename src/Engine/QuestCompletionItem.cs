namespace Engine
{
    public class QuestCompletionItem
    {
        public Item Item { get; set; }

        public int Quantity { get; set; }


        public QuestCompletionItem(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}