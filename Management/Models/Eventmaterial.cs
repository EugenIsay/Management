using System;
using System.Collections.Generic;

namespace Management.Models;

public partial class Eventmaterial
{
    public int Id { get; set; }

    public int Eventid { get; set; }

    public int Materialid { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Material Material { get; set; } = null!;
}
