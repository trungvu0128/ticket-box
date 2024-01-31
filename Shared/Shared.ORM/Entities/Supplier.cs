using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Supplier
{
    public int Id { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Fax { get; set; }

    public string? ContactPerson { get; set; }

    public string? Email { get; set; }

    public string? TaxNumber { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? CountryId { get; set; }

    public virtual Country? Country { get; set; }
}
