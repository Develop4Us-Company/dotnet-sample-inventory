using System;

using AppProject.Core.Infrastructure.Database.Entities;

namespace AppProject.Core.Infrastructure.Database.Entities.Inventory;

public class TbStockMovement : BaseEntity
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime MovementDate { get; set; }

    public bool IsOut { get; set; }

    // RowVersion is already in BaseEntity
}
