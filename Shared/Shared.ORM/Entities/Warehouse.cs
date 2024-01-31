using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Warehouse
{
    public int Id { get; set; }

    public string WarehouseName { get; set; } = null!;

    public int? Status { get; set; }

    public int LocationId { get; set; }

    public bool? IsPr { get; set; }

    public string? Sldatabase { get; set; }

    public string? Slsite { get; set; }

    public string? SldescriptionSite { get; set; }

    public int? ProItemStock { get; set; }

    public int? ProBuId { get; set; }

    public string? ProBuName { get; set; }

    public string? SapPlant { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
