using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class NodeEmployee
{
    public int NodeId { get; set; }

    public string EmployeeId { get; set; } = null!;

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Node Node { get; set; } = null!;
}
