using System;
using System.Collections.Generic;

namespace Management.Models;

public partial class Staffstatus
{
    public int Id { get; set; }

    public DateOnly Day { get; set; }

    public int Staffid { get; set; }

    public int? Statusid { get; set; }

    public int? Eventid { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Staff Staff { get; set; } = null!;

    public virtual Daystatus? Status { get; set; }
}
