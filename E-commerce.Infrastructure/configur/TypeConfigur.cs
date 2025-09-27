using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using E_commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.configur
{
    class TypeConfigur : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            //builder.Property(t => t.Name)
            //      .IsRequired()
            //      .HasMaxLength(100);

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).ValueGeneratedNever();

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
