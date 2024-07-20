using DepartmentModule.DTOs;
using DepartmentModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentModule.Extensions
{
    public static class DepartmentExtensions
    {
        public static DepartmentDto ToDto(this Department department)
        {
            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                LogoName = department?.LogoName,

                Logo = department.Logo,
                ParentDepartmentId = department.ParentDepartmentId
            };
        }

        public static Department ToEntity(this DepartmentDto departmentDto)
        {
            return new Department
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Logo = departmentDto.Logo,
                LogoName = departmentDto.LogoName,

                ParentDepartmentId = departmentDto.ParentDepartmentId
            };
        }
    }


}
