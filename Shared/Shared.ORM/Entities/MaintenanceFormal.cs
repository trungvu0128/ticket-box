using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class MaintenanceFormal
{
    public int Id { get; set; }

    public string? FormName { get; set; }

    public bool? IsPrevent { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<MaintenanceType> MaintenanceTypes { get; set; } = new List<MaintenanceType>();
}
