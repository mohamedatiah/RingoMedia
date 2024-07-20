using ReminderModule.DTOs;

namespace ReminderModule.Services
{
    public interface IReminderService
    {
        Task<IEnumerable<ReminderDto>> GetAllRemindersAsync();
        Task<ReminderDto> GetReminderByIdAsync(int id);
        Task CreateReminderAsync(ReminderDto ReminderDto);
        Task UpdateReminderAsync(ReminderDto ReminderDto);
        Task DeleteReminderAsync(int id);
    }
}
