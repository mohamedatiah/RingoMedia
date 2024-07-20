using ReminderModule.DTOs;
using ReminderModule.Models;

namespace ReminderModule.Extensions
{
    public static class ReminderExtensions
    {
        public static ReminderDto ToDto(this Reminder reminder)
        {
            return new ReminderDto
            {
                Id = reminder.Id,
                Title = reminder.Title,
                DateTime = reminder.DateTime
            };
        }

        public static Reminder ToEntity(this ReminderDto reminderDto)
        {
            return new Reminder
            {
                Id = reminderDto.Id,
                Title = reminderDto.Title,
                DateTime = reminderDto.DateTime
            };
        }
    }
}
