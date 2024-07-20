using Microsoft.EntityFrameworkCore;

namespace ReminderModule.Models
{
    public class ReminderDbContext : DbContext
    {
        public ReminderDbContext(DbContextOptions<ReminderDbContext> options) : base(options) { }

        public DbSet<Reminder> Reminders { get; set; }

    }
}
