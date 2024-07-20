using ReminderModule.DTOs;
using ReminderModule.Extensions;
using ReminderModule.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderModule.Services
{
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository _reminderRepository;

        public ReminderService(IReminderRepository reminderRepository)
        {
            _reminderRepository = reminderRepository;
        }

        public async Task<IEnumerable<ReminderDto>> GetAllRemindersAsync()
        {
            var Reminders = await _reminderRepository.GetAllAsync();
            return Reminders.Select(d => d.ToDto());
        }

        public async Task<ReminderDto> GetReminderByIdAsync(int id)
        {
            var Reminder = await _reminderRepository.GetByIdAsync(id);
            return Reminder?.ToDto();
        }

        public async Task CreateReminderAsync(ReminderDto ReminderDto)
        {
            var Reminder = ReminderDto.ToEntity();
            await _reminderRepository.AddAsync(Reminder);
        }

        public async Task UpdateReminderAsync(ReminderDto ReminderDto)
        {
            var Reminder = ReminderDto.ToEntity();
            await _reminderRepository.UpdateAsync(Reminder);
        }

        public async Task DeleteReminderAsync(int id)
        {
            await _reminderRepository.DeleteAsync(id);
        }
    }
}
