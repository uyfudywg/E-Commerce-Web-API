using E_commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.dbContext
{
    public class E_commerceContext : DbContext
    {
       public E_commerceContext(DbContextOptions<E_commerceContext> options) : base(options) {
        
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }





    }
}
