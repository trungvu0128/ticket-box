using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class FlowTreePosition
{
    public string FlowId { get; set; } = null!;

    public int TreeId { get; set; }

    public int PositionId { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Flow Flow { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;

    public virtual Tree Tree { get; set; } = null!;
}
