using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Slgrreason
{
    public string ReasonCode { get; set; } = null!;

    public string ReasonName { get; set; } = null!;

    public bool? IsCreate { get; set; }

    public bool? IsSynceSolomon { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
