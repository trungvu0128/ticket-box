using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class CalibrationType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public bool? IsExternal { get; set; }

    public int? ParamId { get; set; }

    public bool? IsWeek { get; set; }

    public bool? IsMonth { get; set; }

    public bool? IsYear { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Param? Param { get; set; }
}
