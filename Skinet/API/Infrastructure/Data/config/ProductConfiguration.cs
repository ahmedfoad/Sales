using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(a => a.Id);
           
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Description).IsRequired().HasMaxLength(1000);
            builder.HasOne(a => a.ProductBrand).WithMany()
                .HasForeignKey(a=> a.ProductBrandId);
            builder.HasOne(a => a.ProductType).WithMany()
                .HasForeignKey(a=>a.ProductTypeId);
        }
    }
}
