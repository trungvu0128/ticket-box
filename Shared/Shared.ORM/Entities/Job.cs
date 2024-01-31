using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Job
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int? JobTypeId { get; set; }

    public string? MachineTypeId { get; set; }

    public double? TimeLineAbout { get; set; }

    public bool? IsSafaty { get; set; }

    public int? NumOfPerson { get; set; }

    public string? TechStandar { get; set; }

    public string? ToolRequire { get; set; }

    public string? PersonRequire { get; set; }

    public string? JobSign { get; set; }

    public string? DocPath { get; set; }

    public string? Doing { get; set; }

    public string? Note { get; set; }

    public string? JobKey { get; set; }

    public int? MajorId { get; set; }

    public int? WorkerLevelId { get; set; }

    public double? Limit { get; set; }

    public string? Curency { get; set; }

    public int? PriorityId { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual JobType? JobType { get; set; }

    public virtual MachineType? MachineType { get; set; }

    public virtual Major? Major { get; set; }

    public virtual Priority? Priority { get; set; }

    public virtual WorkerLevel? WorkerLevel { get; set; }
}
