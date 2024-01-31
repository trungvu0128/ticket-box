using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Class
{
    public int Id { get; set; }

    public string ClassName { get; set; } = null!;

    public string? Note { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
