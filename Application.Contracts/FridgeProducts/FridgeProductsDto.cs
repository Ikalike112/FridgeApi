using System;

namespace Application.Contracts.FridgeProducts
{
    public class FridgeProductsDto
    {
        public Guid Id { get; set; }
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
