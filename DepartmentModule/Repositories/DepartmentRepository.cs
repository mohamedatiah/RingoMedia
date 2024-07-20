using DepartmentModule.Models;
using DepartmentModule.Repositories;
using Microsoft.EntityFrameworkCore;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(DepartmentDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Department>> GetSubDepartmentsAsync(int departmentId)
    {
        return await _context.Departments
            .Where(d => d.ParentDepartmentId == departmentId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Department>> GetParentDepartmentsAsync(int departmentId)
    {
        var department = await _context.Departments
            .Include(d => d.ParentDepartment)
            .FirstOrDefaultAsync(d => d.Id == departmentId);

        var parents = new List<Department>();

        while (department != null)
        {
            parents.Add(department);
            department = await _context.Departments.FindAsync(department.ParentDepartmentId);
        }

        return parents;
    }

}
