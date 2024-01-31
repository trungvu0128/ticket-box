using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class CostCenter
{
    public int Id { get; set; }

    public string CostCenterCode { get; set; } = null!;

    public string CostCenterName { get; set; } = null!;

    public string? SapName { get; set; }

    public string? SapDesc { get; set; }

    public string? Note { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int LocationId { get; set; }

    public virtual Location Location { get; set; } = null!;
}
