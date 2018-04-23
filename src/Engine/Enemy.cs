using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Enemy : NPC
    {
        public int RewardXP { get; set; }

        public int RewardGold { get; set; }

        public List<LootItem> LootTable { get; set; }


        public Enemy(int id, string name, int maxDamage, int rewardXP, int rewardGold, int currentHP, int maxHP) : base(id, name, maxDamage, currentHP, maxHP)
        {
            RewardXP = rewardXP;
            RewardGold = rewardGold;

            LootTable = new List<LootItem>();
        }
    }
}
