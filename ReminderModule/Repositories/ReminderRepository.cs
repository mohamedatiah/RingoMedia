using ReminderModule.Models;

namespace ReminderModule.Repositories
{


    public class ReminderRepository : Repository<Reminder>, IReminderRepository
    {
        public ReminderRepository(ReminderDbContext context) : base(context)
        {
        }
    }
}
