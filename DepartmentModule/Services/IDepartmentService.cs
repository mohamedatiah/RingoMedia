using DepartmentModule.DTOs;
using DepartmentModule.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepartmentModule.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetSubDepartmentsAsync(int departmentId);
        Task<IEnumerable<DepartmentDto>> GetAllAsync();
        Task<IEnumerable<DepartmentDto>> GetParentDepartmentsAsync(int departmentId);
        Task<DepartmentDto> GetDepartmentByIdAsync(int departmentId);
        Task CreateDepartmentAsync(DepartmentDto department);
        Task UpdateDepartmentAsync(DepartmentDto department);
        Task DeleteDepartmentAsync(int departmentId);
       Task<DepartmentDto> GetDepartmentDeatilsAsync(int id);
    }
}
