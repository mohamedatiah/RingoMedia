using DepartmentModule.DTOs;
using DepartmentModule.Extensions;
using DepartmentModule.Models;
using DepartmentModule.Repositories;
using DepartmentModule.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<IEnumerable<DepartmentDto>> GetSubDepartmentsAsync(int departmentId)
    {
        var entity= await _departmentRepository.GetSubDepartmentsAsync(departmentId);
        return entity.Select(a => a.ToDto());
    }

    public async Task<IEnumerable<DepartmentDto>> GetParentDepartmentsAsync(int departmentId)
    {
        try
        {
            var entity = await _departmentRepository.GetParentDepartmentsAsync(departmentId);
            return entity.Select(a => a.ToDto());
        }catch(Exception ex)
        {
            return null;
        }
    }

    public async Task<DepartmentDto> GetDepartmentByIdAsync(int departmentId)
    {
        var entity = await _departmentRepository.GetByIdAsync(departmentId);
        return entity.ToDto();
    }

    public async Task CreateDepartmentAsync(DepartmentDto department)
    {
        await _departmentRepository.AddAsync(department.ToEntity());
    }

    public async Task UpdateDepartmentAsync(DepartmentDto department)
    {
        await _departmentRepository.UpdateAsync(department.ToEntity());
    }

    public async Task DeleteDepartmentAsync(int departmentId)
    {
        try
        {
            await _departmentRepository.DeleteAsync(departmentId);
        }
        catch (Exception ex)
        {
            // Handle exception or log it
            throw;
        }
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
    {
        var entity= await _departmentRepository.GetAllAsync();
        return entity.Select(a => a.ToDto());
    }
    public async Task<DepartmentDto> GetDepartmentDeatilsAsync(int id)
    {
        try
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            var sub = await _departmentRepository.GetSubDepartmentsAsync(id);
            if (department != null && department.ParentDepartmentId != null)
            {
                var parent = await _departmentRepository.GetParentDepartmentsAsync(department.ParentDepartmentId.Value);
                department.ParentDepartment = parent.FirstOrDefault();
            }
            department.SubDepartments = sub.ToList();
            return department.ToDto();
        }catch(Exception ex)
        {
            return new DepartmentDto();
        }
    }
}
