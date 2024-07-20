using DepartmentModule.Models;

namespace DepartmentModule.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetSubDepartmentsAsync(int departmentId);
        Task<IEnumerable<Department>> GetParentDepartmentsAsync(int departmentId);
    }
}
