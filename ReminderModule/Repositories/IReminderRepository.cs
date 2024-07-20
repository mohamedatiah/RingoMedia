using ReminderModule.Models;

namespace ReminderModule.Repositories
{
    public interface IReminderRepository
    {
        Task<IEnumerable<Reminder>> GetAllAsync();
        Task<Reminder> GetByIdAsync(int id);
        Task AddAsync(Reminder reminder);
        Task UpdateAsync(Reminder reminder);
        Task DeleteAsync(int id);
    }
}
