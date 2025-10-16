using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppProject.Core.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppProject.Core.Infrastructure.Database.Entities.Inventory;

[Table("StockMovements")]
public class TbStockMovement : BaseEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    [Precision(18, 2)]
    public decimal Quantity { get; set; }

    public DateTime MovementDate { get; set; }

    public bool IsOutbound { get; set; }

    [ForeignKey(nameof(ProductId))]
    public TbProduct Product { get; set; } = default!;
}
