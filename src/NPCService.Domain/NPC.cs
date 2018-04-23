using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
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
