using DepartmentModule.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentModule.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        public string? Logo { get; set; }
        public string? LogoName { get; set; }


        public int? ParentDepartmentId { get; set; }
        public DepartmentDto? ParentDepartment { get; set; }
        public ICollection<DepartmentDto>? SubDepartments { get; set; }
    }
}
