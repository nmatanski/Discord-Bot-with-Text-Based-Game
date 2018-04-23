using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Character
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int CurrentHP { get; set; }

        public int MaxHP { get; set; }


        public Character(int id, string name, int currentHP, int maxHP)
        {
            ID = id;
            Name = name;
            CurrentHP = currentHP;
            MaxHP = maxHP;
        }
    }
}
