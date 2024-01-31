using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class MaintenanceType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public int? Position { get; set; }

    public int? MaintenanceFormId { get; set; }

    public int? TotalDay { get; set; }

    public int? JobTypeId { get; set; }

    public int? NumberOfValue { get; set; }

    public bool? IsFailure { get; set; }

    public bool? IsDay { get; set; }

    public bool? IsMonth { get; set; }

    public bool? IsSchedule { get; set; }

    public bool? IsExternal { get; set; }

    public bool? IsMainRequest { get; set; }

    public bool? IsMonitoring { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual JobType? JobType { get; set; }

    public virtual MaintenanceFormal? MaintenanceForm { get; set; }
}
