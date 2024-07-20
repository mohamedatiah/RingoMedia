using DepartmentModule.DTOs;
using DepartmentModule.Services;
using Microsoft.AspNetCore.Mvc;

public class DepartmentController : Controller
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<IActionResult> Index()
    {
        var departments = await _departmentService.GetAllAsync();
        return View(departments);
    }

    public async Task<IActionResult> Create()
    {
        var departments = await _departmentService.GetAllAsync();
        ViewBag.Departments = departments?.Where(a => a.ParentDepartmentId == null).ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DepartmentDto departmentDto, IFormFile Logo)
    {
        if (ModelState.IsValid)
        {
            if (Logo != null && Logo.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Logo.CopyToAsync(memoryStream);
                    departmentDto.Logo = Convert.ToBase64String(memoryStream.ToArray());
                    departmentDto.LogoName = Logo.FileName;
                }
            }
            await _departmentService.CreateDepartmentAsync(departmentDto);
            return RedirectToAction(nameof(Index));
        }
        return View(departmentDto);
    }
    public async Task<IActionResult> GetSubDepartments(int id)
    {
        var subDepartments = await _departmentService.GetSubDepartmentsAsync(id);
        return PartialView("_SubDepartments", subDepartments);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var departments = await _departmentService.GetAllAsync();
        var department = await _departmentService.GetDepartmentByIdAsync(id);
        ViewBag.Departments = departments?.Where(a => a.ParentDepartmentId == null || a.ParentDepartmentId == department?.ParentDepartmentId).ToList();
        return View(department);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(DepartmentDto departmentDto, IFormFile Logo)
    {
        if (ModelState.IsValid)
        {
            if (Logo != null && Logo.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Logo.CopyToAsync(memoryStream);
                    departmentDto.Logo = Convert.ToBase64String(memoryStream.ToArray());
                    departmentDto.LogoName = Logo.FileName;
                }
            }
            await _departmentService.UpdateDepartmentAsync(departmentDto);
            var departments = await _departmentService.GetAllAsync();
            ViewBag.Departments = departments?.Where(a => a.ParentDepartmentId == null).ToList();
            return RedirectToAction(nameof(Index));
        }
        return View(departmentDto);
    }
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var department = await _departmentService.GetDepartmentDeatilsAsync(id.Value);
        return View(department);
    }
}
