using DAL.Database;
using PlayerService.Domain;

namespace PlayerService
{
    public class PlayerManager : IPlayer
    {
        AppDbContext context = new AppDbContext();
    }
}
