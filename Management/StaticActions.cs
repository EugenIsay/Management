using Management.Context;
using Management.Models;
using Management.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management
{
    public static class StaticActions
    {
        public static User2Context DBContext { get; set; } = new User2Context();
        public static List<Department> RawDepartments  = DBContext.Departments.ToList();
        public static List<Dependent> dependents = DBContext.Dependents.ToList();
        public static List<DepartmentDTO> departments = RawDepartments.Where(d => !dependents.Select(s => s.Juniordepartmentid).ToList().Contains(d.Id)).Select(d => new DepartmentDTO(d)).ToList();
        public static List<Staff> staff = DBContext.Staff.Include(s => s.Position).Include(s => s.Cabinet).Include(s => s.Department).ToList();
    }
}
