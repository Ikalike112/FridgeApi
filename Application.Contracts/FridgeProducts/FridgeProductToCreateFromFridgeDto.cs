using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Contracts.FridgeProducts
{
    public class FridgeProductToCreateFromFridgeDto
    {
        [Required]
        public Guid ProductId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Quantity can't be lower than 0")]
        public int? Quantity { get; set; }
    }
}
