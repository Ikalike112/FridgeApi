using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
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
