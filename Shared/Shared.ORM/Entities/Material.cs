using System;
using System.Collections.Generic;

namespace Shared.ORM.Entities;

public partial class Material
{
    public string Id { get; set; } = null!;

    public string MaterialName { get; set; } = null!;

    public int? UnitId { get; set; }

    public string? MaterialModel { get; set; }

    public string? Reason { get; set; }

    public double? InventoryMin { get; set; }

    public double? InventoryMax { get; set; }

    public bool? IsSap { get; set; }

    public bool? IsSol { get; set; }

    public int? DepreciationMonths { get; set; }

    public bool? IsSupplies { get; set; }

    public int? Status { get; set; }

    public string? SapmaterialGroup { get; set; }

    public string? ItemCode { get; set; }

    public string? PartNo { get; set; }

    public double? Price { get; set; }

    public int? MaterialTypeId { get; set; }

    public bool? IsMeasureTool { get; set; }

    public int? OrderTypeId { get; set; }

    public int? PonumOfDay { get; set; }

    public string? CustomerId { get; set; }

    public double? QuantityOfPo { get; set; }

    public int? ProducerId { get; set; }

    public int? LocationId { get; set; }

    public int? ClassId { get; set; }

    public bool? IsForeign { get; set; }

    public int? ServiceId { get; set; }

    public bool? IsWarehouse { get; set; }

    public string? CreateBy { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? PeriodAssign { get; set; }

    public int? WarehouseId { get; set; }

    public string? Image { get; set; }

    public string? Doc { get; set; }

    public string? Image2 { get; set; }

    public string? Acc { get; set; }

    public string? AccDescription { get; set; }

    public string? SearchTerm { get; set; }

    public bool? IsBatchNumber { get; set; }

    public virtual Class? Class { get; set; }

    public virtual MaterialType? MaterialType { get; set; }

    public virtual OrderType? OrderType { get; set; }

    public virtual Unit? Unit { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}
