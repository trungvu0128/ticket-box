using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class JobType
{
    public int Id { get; set; }

    public string JobTypeName { get; set; } = null!;

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<MaintenanceType> MaintenanceTypes { get; set; } = new List<MaintenanceType>();

    public virtual ICollection<Param> Params { get; set; } = new List<Param>();
}
