using ReminderModule.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
