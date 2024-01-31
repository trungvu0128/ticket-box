using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class UnitMeasure
{
    public int Id { get; set; }

    public string UnitName { get; set; } = null!;

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Param> Params { get; set; } = new List<Param>();
}
