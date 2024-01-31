using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class MaintenanceSystem
{
    public int Id { get; set; }

    public string SystemName { get; set; } = null!;

    public string? Note { get; set; }

    public string? SystemKey { get; set; }

    public int? Number { get; set; }

    public string? DocPath { get; set; }

    public bool? IsNoLine { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
