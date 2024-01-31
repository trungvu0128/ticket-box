using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Unit
{
    public int Id { get; set; }

    public string UnitName { get; set; } = null!;

    public int UnitType { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual ICollection<Param> Params { get; set; } = new List<Param>();
}
