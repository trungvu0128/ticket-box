using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Flow
{
    public string Id { get; set; } = null!;

    public string FlowName { get; set; } = null!;

    public int Status { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<FlowTreePosition> FlowTreePositions { get; set; } = new List<FlowTreePosition>();
}
