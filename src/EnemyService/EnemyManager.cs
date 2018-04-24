using DAL.Database;
using EnemyService.Domain;

namespace Engine.Services.Services
{
    public class EnemyManager : IEnemy
    {
        AppDbContext context = new AppDbContext();
    }
}
