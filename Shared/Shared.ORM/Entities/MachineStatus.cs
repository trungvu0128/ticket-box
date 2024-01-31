using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class MachineStatus
{
    public int Id { get; set; }

    public string MachineStatusName { get; set; } = null!;

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
