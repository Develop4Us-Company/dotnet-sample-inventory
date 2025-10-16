using System;
using System.ComponentModel.DataAnnotations;
using AppProject.Models;
using AppProject.Models.CustomValidators;

namespace AppProject.Core.Models.Inventory;

public class StockMovement : IEntity
{
    public Guid? Id { get; set; }

    [RequiredGuid]
    public Guid ProductId { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Quantity { get; set; }

    [Required]
    public DateTime MovementDate { get; set; }

    public bool IsOutbound { get; set; }

    public byte[]? RowVersion { get; set; }
}
