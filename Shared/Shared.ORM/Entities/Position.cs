using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Position
{
    public int Id { get; set; }

    public string PositionName { get; set; } = null!;

    public int? ParentId { get; set; }

    public string? Note { get; set; }

    public int Status { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<CostCenter> CostCenters { get; set; } = new List<CostCenter>();

    public virtual ICollection<FlowTreePosition> FlowTreePositions { get; set; } = new List<FlowTreePosition>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
