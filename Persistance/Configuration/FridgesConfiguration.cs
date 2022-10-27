using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence.Configuration
{
    public class FridgesConfiguration : IEntityTypeConfiguration<Fridge>
    {
        public void Configure(EntityTypeBuilder<Fridge> builder)
        {
            builder.HasData(
                new Fridge
                {
                    Id = Guid.Parse("7870E84D-0F97-4196-BED7-19BD8FF40A63"),
                    Name = "Electrolux Dima",
                    OwnerName = "Dima",
                    FridgeModelId = Guid.Parse("B12741D6-4EA0-4CE4-8A4E-3BE45767B928")
                },
                new Fridge
                {
                    Id = Guid.Parse("B97C170D-A6BF-4F26-8231-28D9025BF3AD"),
                    Name = "ATLANT Vlad",
                    OwnerName = "Vlad",
                    FridgeModelId = Guid.Parse("B0463F44-AF0C-434F-9667-C3BF6C9F8A93")
                },
                new Fridge
                {
                    Id = Guid.Parse("557D35EF-AB80-4E17-A96C-2B65CF3DD7BF"),
                    Name = "Electrolux Sasha",
                    OwnerName = "Sasha",
                    FridgeModelId = Guid.Parse("B12741D6-4EA0-4CE4-8A4E-3BE45767B928")
                },
                new Fridge
                {
                    Id = Guid.Parse("72E0A604-0877-4510-9701-F3B29EAD9D9D"),
                    Name = "Lg Inessa",
                    OwnerName = "Inessa",
                    FridgeModelId = Guid.Parse("D957B9BE-B351-4629-A332-4841851AA395")
                },
                new Fridge
                {
                    Id = Guid.Parse("78F6F534-8B95-44B7-88E3-6C395C53207E"),
                    Name = "Indesit Roma",
                    OwnerName = "Roman",
                    FridgeModelId = Guid.Parse("2767F531-6EAB-492B-99FA-839B826552E9")
                }
            );
        }
    }
}
