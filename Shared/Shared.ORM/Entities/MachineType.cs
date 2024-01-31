using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class MachineType
{
    public string Id { get; set; } = null!;

    public string MachineTypeName { get; set; } = null!;

    public int? Position { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
