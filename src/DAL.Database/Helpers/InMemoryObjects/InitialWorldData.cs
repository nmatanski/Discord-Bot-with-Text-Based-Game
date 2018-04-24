using ItemService.Domain.Models;
using System.Collections.Generic;
using WeaponService.Domain.Models;

namespace DAL.Database.Helpers.InMemoryObjects
{
    public static class InitialWorldData
    {
        private static List<Item> GetInitialItems()
        {
            return new List<Item>()
            {
                new Weapon(1, "Small Dagger", "Small Daggers", 0, 5, 20)
            };
        }
    }
}
