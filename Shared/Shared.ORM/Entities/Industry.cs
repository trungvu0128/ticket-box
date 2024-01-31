using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Industry
{
    public string IndustryId { get; set; } = null!;

    public string IndustryName { get; set; } = null!;

    public virtual ICollection<Bu> Bus { get; set; } = new List<Bu>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
