
using CharacterService.Domain.Models;
using ItemService.Domain.Models;
using LocationService.Domain.Models;
using QuestService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using WeaponService.Domain.Models;

namespace PlayerService.Domain.Models
{
    public class Player : Character
    {
        public int Gold { get; set; }

        public int XP { get; private set; } ///TODO: protected set? -> user.player.XP ?

        public int XPNeeded { get { return 10 * Level * Level + 90 * Level - XP; } }

        public int Level { get => (int)Math.Floor(((-90 + Math.Sqrt(8100 + 40 * XP)) / 20 + 1)); }

        public List<InventoryItem> Inventory { get; set; }

        public List<PlayerQuest> Quests { get; set; }

        public Location CurrentLocation { get; set; }

        public Weapon CurrentWeapon { get; set; }


        public Player(int id, string name, int currentHP, int maxHP) : base(id, name, currentHP, maxHP) { }

        private Player(int id, string name, int currentHP, int maxHP, int gold, int xp) : base(id, name, currentHP, maxHP)
        {
            Gold = gold;
            XP = xp;

            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }

        public static Player CreateDefaultPlayer()
        {
            Player player = new Player(1, "Seed", 10, 10, 20, 0);
            //player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_BROKEN_SWORD), 1));
            //player.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);

            return player;
        }

        public void AddExperiencePoints(int experiencePointsToAdd)
        {
            XP += experiencePointsToAdd < 0 ? 0 : experiencePointsToAdd;

            switch (Level)
            {
                case 1:
                    MaxHP = 10;
                    break;
                case 2:
                    MaxHP = 21;
                    break;
                case 3:
                    MaxHP = 32;
                    break;
                default:
                    MaxHP = 2 * (Level * Level + 2 * Level - 1);
                    break;
            }
        }

        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if (location.ItemRequiredToEnter == null)
            {
                // Няма required items за тази локация, така че излез с true
                return true;
            }
            // Намерен е предмет от Inventory (true) или играчът няма нужният предмет за преминаване false
            return Inventory.Any(ii => ii.Item.ID == location.ItemRequiredToEnter.ID);
        }

        public bool HasThisQuest(Quest quest)
        {
            foreach (var playerQuest in Quests)
                if (playerQuest.Quest.ID == quest.ID)
                    return true;
            return false;
        }

        public bool CompletedThisQuest(Quest quest)
        {
            foreach (var playerQuest in Quests)
                if (playerQuest.Quest.ID == quest.ID)
                    return playerQuest.IsCompleted;
            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            // Обхожда цялото Inventory, за да провери дали играчът притежава quest item и дали има нужната бройка да завърши quest-a
            foreach (var qci in quest.QuestCompletionItems)
                if (!Inventory.Any(ii => ii.Item.ID == qci.Item.ID && ii.Quantity >= qci.Quantity))
                    return false;

            // Следователно играчът има нужният item и достатъчна бройка от него, за да приключи Quest-a
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (var qci in quest.QuestCompletionItems)
            {
                var item = Inventory.SingleOrDefault(ii => ii.Item.ID == qci.Item.ID);
                // Извади нужния брой quest items от броя им в Inventory 
                if (item != null)
                    item.Quantity -= qci.Quantity;
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            // Обхожда Inventory, за да провери дали reward item-a го няма вече в Inventory
            var item = Inventory.SingleOrDefault(ii => ii.Item.ID == itemToAdd.ID);

            if (item == null) // Добави reward item-a като нов InventoryItem (на нов слот) с брой 1
                Inventory.Add(new InventoryItem(itemToAdd, 1));
            else // RewardItem се съдържа в Inventory, затова само увеличи броя с 1
                item.Quantity++;
        }

        public void MarkQuestAsCompleted(Quest quest)
        {
            // Обходи списъка с quests и намери quest-ът, който току що завърши
            var playerQuest = Quests.SingleOrDefault(pq => pq.Quest.ID == quest.ID);
            if (playerQuest != null)
                playerQuest.IsCompleted = true; // Отбележи го като completed
        }


        public static Player CreatePlayerFromDBCheckpoint() // useless?
        {
            throw new NotImplementedException();
        }

        public void FullSyncToDB()
        {
            /// Player Data
            // Stats: CurrentHP, MaxHP, Gold, XP, CurrentLocation, Current weapon if not null
            // Inventory: whole Inventory (all InventoryItem instances)
            // Quests: whole Quest Log (all PlayerQuest instances)

            throw new NotImplementedException();
        }

    }
}
