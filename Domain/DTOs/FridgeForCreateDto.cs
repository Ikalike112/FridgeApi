using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class FridgeForCreateDto
    {

        [Required(ErrorMessage = "Fridge name is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for the Name is 200 characters.")]
        public string Name { get; set; }
        [MaxLength(200, ErrorMessage = "Maximum length for the OwnerName is 200 characters.")]
        public string? OwnerName { get; set; }
        [Required(ErrorMessage = "FridgeModelId is a required field.")]
        public Guid FridgeModelId { get; set; }
    }
}
