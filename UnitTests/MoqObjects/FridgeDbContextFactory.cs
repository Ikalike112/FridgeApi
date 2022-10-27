using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;

namespace UnitTests.MoqObjects
{
    public class FridgeDbContextFactory
    {
        public static FridgeDbContext Create()
        {
            var options = new DbContextOptionsBuilder<FridgeDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options;
            var context = new FridgeDbContext(options);
            context.Database.EnsureCreated();
            context.FridgeModels.AddRange(
                    new FridgeModel
                    {
                        Id = Guid.Parse("3BFD5E1C-8407-4D3E-B77B-30427468656E"),
                        Name = "Samsung RB34A7B4F35/WT",
                        Year = 2020
                    },
                    new FridgeModel
                    {
                        Id = Guid.Parse("D957B9BE-B351-4629-A332-4841851AA395"),
                        Name = "LG DoorCooling+ GA-B509CQTL",
                        Year = 2020
                    },
                    new FridgeModel
                    {
                        Id = Guid.Parse("B12741D6-4EA0-4CE4-8A4E-3BE45767B928"),
                        Name = "Electrolux KNT2LF18S",
                        Year = 2019
                    },
                    new FridgeModel
                    {
                        Id = Guid.Parse("B0463F44-AF0C-434F-9667-C3BF6C9F8A93"),
                        Name = "ATLANT ХМ 4307-000",
                        Year = 2017
                    },
                    new FridgeModel
                    {
                        Id = Guid.Parse("2767F531-6EAB-492B-99FA-839B826552E9"),
                        Name = "Indesit ITR 5200 W",
                        Year = 2020
                    }
                );
            context.Fridges.AddRange(
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
                    }
                );

            context.Products.AddRange(
                new Product
                {
                    Id = Guid.Parse("5D25FFB3-2F6B-4911-974D-A35F34CA7014"),
                    Name = "Sour cream",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = Guid.Parse("413CE5BA-F360-4C4C-8F7E-CD26667FE5FF"),
                    Name = "Curd",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = Guid.Parse("60AA9097-9F29-4F08-B0BD-B07A68B9DA43"),
                    Name = "Bread",
                    DefaultQuantity = 1
                },
                new Product
                {
                    Id = Guid.Parse("A3DB9CB6-4D70-44FC-B140-969B5594A56E"),
                    Name = "Сucumbers",
                    DefaultQuantity = 5
                },
                new Product
                {
                    Id = Guid.Parse("C30B9AC9-BDBA-4EDC-AA9C-AD3DDA4814AE"),
                    Name = "Apples",
                    DefaultQuantity = 4
                }
                );
            context.FridgeProducts.AddRange(
                new FridgeProducts
                {
                    Id = Guid.Parse("E0E12E03-2F7C-4A49-8B5C-602CE5786F28"),
                    FridgeId = Guid.Parse("7870E84D-0F97-4196-BED7-19BD8FF40A63"),
                    ProductId = Guid.Parse("413CE5BA-F360-4C4C-8F7E-CD26667FE5FF"),
                    Quantity = 3
                },
                new FridgeProducts
                {
                    Id = Guid.Parse("CE9CCA0D-44AF-4ED0-94E4-ADA2281D3CDA"),
                    FridgeId = Guid.Parse("7870E84D-0F97-4196-BED7-19BD8FF40A63"),
                    ProductId = Guid.Parse("60AA9097-9F29-4F08-B0BD-B07A68B9DA43"),
                    Quantity = 1
                },
                new FridgeProducts
                {
                    Id = Guid.Parse("CF6E9D69-3EB9-4F73-AC12-25A09D016A6C"),
                    FridgeId = Guid.Parse("7870E84D-0F97-4196-BED7-19BD8FF40A63"),
                    ProductId = Guid.Parse("C30B9AC9-BDBA-4EDC-AA9C-AD3DDA4814AE"),
                    Quantity = 15
                },
                new FridgeProducts
                {
                    Id = Guid.Parse("05DA7993-8BC2-4A92-A1C7-C282AF54DEF9"),
                    FridgeId = Guid.Parse("557D35EF-AB80-4E17-A96C-2B65CF3DD7BF"),
                    ProductId = Guid.Parse("413CE5BA-F360-4C4C-8F7E-CD26667FE5FF"),
                    Quantity = 1
                },
                new FridgeProducts
                {
                    Id = Guid.Parse("EC994091-00A1-41F5-BF8F-6ABE3B4863A3"),
                    FridgeId = Guid.Parse("557D35EF-AB80-4E17-A96C-2B65CF3DD7BF"),
                    ProductId = Guid.Parse("5D25FFB3-2F6B-4911-974D-A35F34CA7014"),
                    Quantity = 2
                },
                new FridgeProducts
                {
                    Id = Guid.Parse("14E4C28D-4ED9-41CD-95EB-F66F8C9BFE60"),
                    FridgeId = Guid.Parse("557D35EF-AB80-4E17-A96C-2B65CF3DD7BF"),
                    ProductId = Guid.Parse("C30B9AC9-BDBA-4EDC-AA9C-AD3DDA4814AE"),
                    Quantity = 0
                },
                new FridgeProducts
                {
                    Id = Guid.Parse("BFFDC898-D59F-485D-A748-90DF10A1E8C9"),
                    FridgeId = Guid.Parse("B97C170D-A6BF-4F26-8231-28D9025BF3AD"),
                    ProductId = Guid.Parse("A3DB9CB6-4D70-44FC-B140-969B5594A56E"),
                    Quantity = 0
                }
                );
            context.SaveChanges();
            return context;            
        }
        public static void Destroy(FridgeDbContext context)
        {
            context.Database.EnsureCreated();
            context.Dispose();
        }
    }
}
