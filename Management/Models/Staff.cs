using System;
using System.Collections.Generic;

namespace Management.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string FullName
    {
        get => Name + " " + Surname + " " + Patronymic;
    }

    public DateOnly Birthday { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Departmentid { get; set; }

    public int Positionid { get; set; }

    public int Cabinetid { get; set; }

    public virtual Cabinet Cabinet { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual Position Position { get; set; } = null!;

    public virtual ICollection<Staffstatus> Staffstatuses { get; set; } = new List<Staffstatus>();
}
