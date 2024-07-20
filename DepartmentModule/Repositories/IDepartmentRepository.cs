using DepartmentModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentModule.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetSubDepartmentsAsync(int departmentId);
        Task<IEnumerable<Department>> GetParentDepartmentsAsync(int departmentId);
    }
}
