using System;
using Application.Contracts.Products;

namespace Application.Contracts.FridgeProducts
{
    public class FridgeProductsByFridgeIdDto
    {
        public Guid Id { get; set; }
        public ProductsDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
