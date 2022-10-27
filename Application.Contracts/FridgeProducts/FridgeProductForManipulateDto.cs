using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Contracts.FridgeProducts
{
    public class FridgeProductForManipulateDto
    {
        [Required(ErrorMessage = "FridgeId is a required field.")]
        public Guid FridgeId { get; set; }
        [Required(ErrorMessage = "ProductId is a required field.")]
        public Guid ProductId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Quantity can't be lower than 0")]
        public int? Quantity { get; set; }
    }
}
