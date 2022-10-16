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
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = Guid.Parse("5D25FFB3-2F6B-4911-974D-A35F34CA7014"),
                    Name = "Sour cream",
                    DefaultQuantity = 1,
                    ImageSource = "https://localhost:5001/Images/sourcream.jpg"
                },
                new Product
                {
                    Id = Guid.Parse("413CE5BA-F360-4C4C-8F7E-CD26667FE5FF"),
                    Name = "Curd",
                    DefaultQuantity = 1,
                    ImageSource = "https://localhost:5001/Images/curd.webp"
                },
                new Product
                {
                    Id = Guid.Parse("60AA9097-9F29-4F08-B0BD-B07A68B9DA43"),
                    Name = "Bread",
                    DefaultQuantity = 1,
                    ImageSource = "https://localhost:5001/Images/bread.jpg"
                },
                new Product
                {
                    Id = Guid.Parse("A3DB9CB6-4D70-44FC-B140-969B5594A56E"),
                    Name = "Сucumbers",
                    DefaultQuantity = 5,
                    ImageSource = "https://localhost:5001/Images/cucumbers.jpg"
                },
                new Product
                {
                    Id = Guid.Parse("C30B9AC9-BDBA-4EDC-AA9C-AD3DDA4814AE"),
                    Name = "Apples",
                    DefaultQuantity = 4,
                    ImageSource = "https://localhost:5001/Images/apples.jpg"
                },
                new Product
                {
                    Id = Guid.Parse("1B098F23-F8D9-4F7C-9385-20D620E176B6"),
                    Name = "Buckwheat",
                    DefaultQuantity = 1,
                    ImageSource = "https://localhost:5001/Images/buckwheat.webp"
                }
            );
        }
    }
}
