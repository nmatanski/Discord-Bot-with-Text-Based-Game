using DAL.Database;
using ItemService.Domain;

namespace Engine.Services.Services
{
    public class ItemManager : IItem
    {
        AppDbContext context = new AppDbContext();
    }
}
