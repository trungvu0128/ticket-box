using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Param
{
    public int Id { get; set; }

    public string ParamName { get; set; } = null!;

    public bool? IsQuantitative { get; set; }

    public string? Note { get; set; }

    public int? UnitId { get; set; }

    public string? Path { get; set; }

    public int? JobTypeId { get; set; }

    public string? Doing { get; set; }

    public string? Time { get; set; }

    public string? PersonRequire { get; set; }

    public string? ToolRequire { get; set; }

    public string? TechStandar { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<CalibrationType> CalibrationTypes { get; set; } = new List<CalibrationType>();

    public virtual JobType? JobType { get; set; }

    public virtual Unit? Unit { get; set; }
}
