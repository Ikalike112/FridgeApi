using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class FridgeModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is a required field")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters")]
        public string Name { get; set; }
        [Range(1900, int.MaxValue, ErrorMessage = "Year can't be lower than 1900")]
        public int? Year { get; set; }
        public ICollection<Fridge> Fridges { get; set; }
    }
}
