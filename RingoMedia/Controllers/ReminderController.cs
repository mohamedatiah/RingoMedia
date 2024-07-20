using Microsoft.AspNetCore.Mvc;
using ReminderModule.DTOs;
using ReminderModule.Models;
using ReminderModule.Services;
using System.Threading.Tasks;

public class ReminderController : Controller
{
    private readonly IReminderService _reminderService;


    public ReminderController(IReminderService reminderService)
    {
        _reminderService = reminderService;
    }

    public async Task<IActionResult> Index()
    {
        var reminders = await _reminderService.GetAllRemindersAsync();
        return View(reminders);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ReminderDto reminderDto)
    {
        if (ModelState.IsValid)
        {
            await _reminderService.CreateReminderAsync(reminderDto);
            return RedirectToAction(nameof(Index));
        }
        return View(reminderDto);
    }

    public async Task<IActionResult>Edit(int id)
    {
        var reminder =await _reminderService.GetReminderByIdAsync(id);
        if (reminder == null)
        {
            return NotFound();
        }
        return View(reminder);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ReminderDto reminder)
    {
        if (ModelState.IsValid)
        {
          await _reminderService.UpdateReminderAsync(reminder);
            return RedirectToAction("Index");
        }
        return View(reminder);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var reminder =await _reminderService.GetReminderByIdAsync(id);
        if (reminder == null)
        {
            return NotFound();
        }
        return View(reminder);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
     await   _reminderService.DeleteReminderAsync(id);
        return RedirectToAction("Index");
    }
}
