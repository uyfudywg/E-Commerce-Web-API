using E_commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.configur
{
    class BrandConfigur : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            //builder.Property(b => b.Name)
            //       .IsRequired()
            //       .HasMaxLength(100);

            builder.HasKey(b => b.Id);

            // عشان يسمح بالـ Id اللي جاي من JSON
            builder.Property(b => b.Id).ValueGeneratedNever();

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
