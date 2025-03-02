using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Management.Models.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<DepartmentDTO> SubDepartments { get; set; }

        public DepartmentDTO(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            SubDepartments = StaticActions.RawDepartments.Where(d => StaticActions.dependents.Where(s => s.Masterdepartmentid == Id).Select(s => s.Juniordepartmentid).Contains(d.Id)).Select(d => new DepartmentDTO(d)).ToList();

        }
    }
}
