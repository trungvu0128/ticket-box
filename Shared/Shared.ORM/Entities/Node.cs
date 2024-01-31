using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Node
{
    public int Id { get; set; }

    public string NodeName { get; set; } = null!;

    public int TreeId { get; set; }

    public int Position { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<NodeEmployee> NodeEmployees { get; set; } = new List<NodeEmployee>();

    public virtual Tree Tree { get; set; } = null!;
}
