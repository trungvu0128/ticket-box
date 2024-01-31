using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class CostType
{
    public int Id { get; set; }

    public string CostTypeName { get; set; } = null!;

    public string? Note { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
