﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ProductForManipulateDto
    {
        [Required(ErrorMessage = "Product name can't be null")]
        public string Name { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity can't be lower than 0")]
        public int DefaultQuantity { get; set; }
        public IFormFile Image { get; set; }
    }
}
