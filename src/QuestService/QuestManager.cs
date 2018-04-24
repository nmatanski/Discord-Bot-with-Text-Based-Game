using DAL.Database;
using QuestService.Domain;

namespace QuestService
{
    public class QuestManager : IQuest
    {
        AppDbContext context = new AppDbContext();
    }
}
