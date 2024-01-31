using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Document
{
    public int Id { get; set; }

    public string DocumentName { get; set; } = null!;

    public string? FileName { get; set; }

    public string? FilePath { get; set; }

    public string CreateBy { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }
}
