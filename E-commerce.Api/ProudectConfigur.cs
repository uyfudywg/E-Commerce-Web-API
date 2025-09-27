using E_commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Infrastructure.Configurations
{
    // Corrected the class name to match the file name and avoid confusion
    public class ProudectConfigur : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(p => p.Description)
                   .HasMaxLength(500);

            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.PictureUrl)
                   .HasMaxLength(200);

            builder.HasOne(p => p.Brand)
                   .WithMany(b => b.Products)
                   .HasForeignKey(p => p.BrandId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.ProductType)
                   .WithMany(t => t.Products)
                   .HasForeignKey(p => p.ProductTypeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
