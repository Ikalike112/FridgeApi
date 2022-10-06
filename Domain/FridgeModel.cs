﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FridgeModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Name is a required field")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters")]
        public string Name { get; set; }
        public int? Year { get; set; }
        public ICollection<Fridge> Fridges { get; set; }
    }
}