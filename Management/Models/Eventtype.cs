using System;
using System.Collections.Generic;

namespace Management.Models;

public partial class Eventtype
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
