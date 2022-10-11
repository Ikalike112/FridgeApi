using Domain;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFridgeDbContext
    {
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<FridgeProducts> FridgeProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken token);
        public void ChangeZeroQuantity();
    }
}
