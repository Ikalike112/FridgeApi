using Application.Interfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class FridgeDbContext : IdentityDbContext<ApplicationUser>, IFridgeDbContext
    {
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<FridgeProducts> FridgeProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public FridgeDbContext(DbContextOptions<FridgeDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new ProductsConfiguration());
            builder.ApplyConfiguration(new FridgeModelConfiguration());
            builder.ApplyConfiguration(new FridgesConfiguration());
            builder.ApplyConfiguration(new FridgeProductsConfiguration());
        }
        public void ChangeZeroQuantity()
        {
            Database.ExecuteSqlRaw("EXEC dbo.sp_ChangeZeroQuantity");
           // FridgeProducts.FromSqlRaw("EXEC dbo.sp_ChangeZeroQuantity");
        }  
    }
}
