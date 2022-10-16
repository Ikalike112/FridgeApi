using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class FridgeProductsConfiguration : IEntityTypeConfiguration<FridgeProducts>
    {
        public void Configure(EntityTypeBuilder<FridgeProducts> builder)
        {
            builder.HasData(
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
                },
                new FridgeProducts
                {
                    Id = Guid.Parse("3D0EE611-17E8-43B6-9CEB-FF117EAAA79C"),
                    FridgeId = Guid.Parse("72E0A604-0877-4510-9701-F3B29EAD9D9D"),
                    ProductId = Guid.Parse("1B098F23-F8D9-4F7C-9385-20D620E176B6"),
                    Quantity = 3
                },
                new FridgeProducts
                {
                    Id = Guid.Parse("52956EC3-022E-49DE-B2C9-F2229478BBD8"),
                    FridgeId = Guid.Parse("72E0A604-0877-4510-9701-F3B29EAD9D9D"),
                    ProductId = Guid.Parse("413CE5BA-F360-4C4C-8F7E-CD26667FE5FF"),
                    Quantity = 7
                },
                new FridgeProducts
                {
                    Id = Guid.Parse("FFD7F7CE-DD5D-4610-93A9-A57C1C14B2DF"),
                    FridgeId = Guid.Parse("72E0A604-0877-4510-9701-F3B29EAD9D9D"),
                    ProductId = Guid.Parse("A3DB9CB6-4D70-44FC-B140-969B5594A56E"),
                    Quantity = 3
                },
                new FridgeProducts
                {
                    Id = Guid.Parse("5C23A099-37F7-45E3-88F7-80119EB8A4F0"),
                    FridgeId = Guid.Parse("78F6F534-8B95-44B7-88E3-6C395C53207E"),
                    ProductId = Guid.Parse("A3DB9CB6-4D70-44FC-B140-969B5594A56E"),
                    Quantity = 3
                },
                new FridgeProducts
                {
                    Id = Guid.Parse("681DD588-F9FD-4CF5-93C6-028ADAA79F87"),
                    FridgeId = Guid.Parse("78F6F534-8B95-44B7-88E3-6C395C53207E"),
                    ProductId = Guid.Parse("413CE5BA-F360-4C4C-8F7E-CD26667FE5FF"),
                    Quantity = 7
                },
                new FridgeProducts
                {
                    Id = Guid.Parse("E73AF1A7-0F1A-4762-8D81-4FE406FA353B"),
                    FridgeId = Guid.Parse("78F6F534-8B95-44B7-88E3-6C395C53207E"),
                    ProductId = Guid.Parse("60AA9097-9F29-4F08-B0BD-B07A68B9DA43"),
                    Quantity = 3
                }
            );
        }
    }
}