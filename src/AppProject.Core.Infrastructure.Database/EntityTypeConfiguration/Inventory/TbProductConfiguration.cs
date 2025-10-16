using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppProject.Core.Infrastructure.Database.Entities.Inventory;

namespace AppProject.Core.Infrastructure.Database.EntityTypeConfiguration.Inventory;

public class TbProductConfiguration : IEntityTypeConfiguration<TbProduct>
{
    public void Configure(EntityTypeBuilder<TbProduct> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(x => x.Code).HasMaxLength(100);
        builder.Property(x => x.MinimumStockQuantity).IsRequired();
        builder.Property(x => x.RowVersion).IsRowVersion();
    }
}
