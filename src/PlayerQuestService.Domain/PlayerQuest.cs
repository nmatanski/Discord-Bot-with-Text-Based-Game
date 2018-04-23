using System.ComponentModel.DataAnnotations;

namespace Engine
{
    public class PlayerQuest
    {
        [Key]
        public int ID { get; set; }

        public Quest Quest { get; set; }

        public bool IsCompleted { get; set; }

        public string Name { get => Quest.Name; }


        public PlayerQuest(Quest quest)
        {
            Quest = quest;
            IsCompleted = false;
        }
    }
}