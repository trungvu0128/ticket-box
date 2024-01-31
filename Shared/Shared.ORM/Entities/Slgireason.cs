using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Slgireason
{
    public string Id { get; set; } = null!;

    public string ReasonName { get; set; } = null!;

    public string? Slaccount { get; set; }

    public string? SldescriptionAcc { get; set; }

    public bool? IsShowWhenCreate { get; set; }

    public bool? IsMainVoteRequired { get; set; }

    public bool? IsAccessoryOnly { get; set; }

    public bool? IsSuppliesOnly { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
