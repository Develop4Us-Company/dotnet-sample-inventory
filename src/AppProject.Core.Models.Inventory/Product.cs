using System;
using System.ComponentModel.DataAnnotations;
using AppProject.Models;

namespace AppProject.Core.Models.Inventory;

public class Product : IEntity
{
    public Guid? Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = default!;

    [MaxLength(100)]
    public string? Code { get; set; }

    public int MinimumStockQuantity { get; set; }

    public byte[]? RowVersion { get; set; }
}
