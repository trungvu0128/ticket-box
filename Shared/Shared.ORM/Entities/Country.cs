using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Country
{
    public string Id { get; set; } = null!;

    public string CountryName { get; set; } = null!;

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
