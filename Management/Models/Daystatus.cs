using System;
using System.Collections.Generic;

namespace Management.Models;

public partial class Daystatus
{
    public int Id { get; set; }

    public string Day { get; set; } = null!;

    public virtual ICollection<Staffstatus> Staffstatuses { get; set; } = new List<Staffstatus>();
}
