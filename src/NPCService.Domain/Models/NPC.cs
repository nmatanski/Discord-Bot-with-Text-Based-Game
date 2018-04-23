using CharacterService.Domain.Models;

namespace NPCService.Domain.Models
{
    public class NPC : Character
    {
        public int MaxDamage { get; set; }


        public NPC(int id, string name, int maxDamage, int currentHP, int maxHP) : base(id, name, currentHP, maxHP)
        {
            Name = name;
            MaxDamage = maxDamage;
        }
    }
}
