using DepartmentModule.Models;
using Microsoft.EntityFrameworkCore;
using ReminderModule.Models;

namespace RingoMedia.Models
{
    //public class ApplicationDbContext:DbContext
    //{
    //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //    public DbSet<Department> Departments { get; set; }
    //    public DbSet<Reminder> Reminders { get; set; }
    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Department>()
    //            .HasMany(d => d.SubDepartments)
    //            .WithOne(d => d.ParentDepartment)
    //            .HasForeignKey(d => d.ParentDepartmentId)
    //            .OnDelete(DeleteBehavior.Restrict);
    //    }
    //}
}
