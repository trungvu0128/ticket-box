using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Bu
{
    public int Buid { get; set; }

    public string Bucode { get; set; } = null!;

    public string Buname { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? IndustryId { get; set; }

    public virtual Industry? Industry { get; set; }
}
