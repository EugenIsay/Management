using System;
using System.Collections.Generic;

namespace Management.Models;

public partial class Dependent
{
    public int Masterdepartmentid { get; set; }

    public int Juniordepartmentid { get; set; }

    public virtual Department Juniordepartment { get; set; } = null!;

    public virtual Department Masterdepartment { get; set; } = null!;
}
