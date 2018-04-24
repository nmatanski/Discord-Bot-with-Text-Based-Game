using QuestService.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerService.Domain.Models
{
    public class PlayerQuest
    {
        [Key]
        public int ID { get; set; }

        public Quest Quest { get; set; }

        public bool IsCompleted { get; set; }

        public string Name { get => Quest.Name; }

        [ForeignKey("Player")]
        public int PlayerID { get; set; }

        public virtual Player Player { get; set; }



        public PlayerQuest(Quest quest)
        {
            Quest = quest;
            IsCompleted = false;
        }
    }
}