using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Producer
{
    public int Id { get; set; }

    public string ProducerName { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
