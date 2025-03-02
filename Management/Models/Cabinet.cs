using System;
using System.Collections.Generic;

namespace Management.Models;

public partial class Cabinet
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
