using System;
using System.Collections.Generic;

namespace Management.Models;

public partial class Material
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly Comfirmdate { get; set; }

    public DateOnly Changedate { get; set; }

    public int Statusid { get; set; }

    public int Typeid { get; set; }

    public string? Area { get; set; }

    public string? Author { get; set; }

    public virtual ICollection<Eventmaterial> Eventmaterials { get; set; } = new List<Eventmaterial>();

    public virtual Materialstatus Status { get; set; } = null!;

    public virtual Materialtype Type { get; set; } = null!;
}
