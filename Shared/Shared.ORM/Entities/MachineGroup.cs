using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class MachineGroup
{
    public string Id { get; set; } = null!;

    public string MachineGroupName { get; set; } = null!;

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
