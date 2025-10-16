using System;

using AppProject.Core.Infrastructure.Database.Entities;

namespace AppProject.Core.Infrastructure.Database.Entities.Inventory;

public class TbProduct : BaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string? Code { get; set; }

    public int MinimumStockQuantity { get; set; }

    // RowVersion is already in BaseEntity
}
