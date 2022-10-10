using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class FridgeModelForManipulateDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters")]
        public string Name { get; set; }
        [Range(1900, int.MaxValue, ErrorMessage = "Year can't be lower than 1900")]
        public int? Year { get; set; }
    }
}
