using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppProject.Core.Infrastructure.Database.Entities.Inventory;

namespace AppProject.Core.Infrastructure.Database.EntityTypeConfiguration.Inventory;

public class TbStockMovementConfiguration : IEntityTypeConfiguration<TbStockMovement>
{
    public void Configure(EntityTypeBuilder<TbStockMovement> builder)
    {
        builder.ToTable("StockMovements");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.MovementDate).IsRequired();
        builder.Property(x => x.IsOut).IsRequired();
        builder.Property(x => x.RowVersion).IsRowVersion();
    }
}
