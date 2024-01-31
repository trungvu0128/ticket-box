using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Tree
{
    public int Id { get; set; }

    public string TreeName { get; set; } = null!;

    public int Status { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<FlowTreePosition> FlowTreePositions { get; set; } = new List<FlowTreePosition>();

    public virtual ICollection<Node> Nodes { get; set; } = new List<Node>();
}
