using System;
using System.ComponentModel.DataAnnotations;
using AppProject.Models;

namespace AppProject.Core.Models.Inventory;

public class StockMovement : IEntity
{
    public Guid? Id { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime MovementDate { get; set; }

    public bool IsOut { get; set; }

    public byte[]? RowVersion { get; set; }
}
