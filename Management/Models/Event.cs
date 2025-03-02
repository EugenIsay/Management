using System;
using System.Collections.Generic;

namespace Management.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Eventtypeid { get; set; }

    public int Eventstatusid { get; set; }

    public DateTime Time { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Eventmaterial> Eventmaterials { get; set; } = new List<Eventmaterial>();

    public virtual Eventstatus Eventstatus { get; set; } = null!;

    public virtual Eventtype Eventtype { get; set; } = null!;

    public virtual ICollection<Staffstatus> Staffstatuses { get; set; } = new List<Staffstatus>();
}
