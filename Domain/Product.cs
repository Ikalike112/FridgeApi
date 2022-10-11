using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters")]
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }
        [MaxLength(100, ErrorMessage = "Maximum length for the ImageSource is 100 characters")]
        public string? ImageSource { get; set; }
        public ICollection<FridgeProducts> FridgeProducts { get; set; }
    }
}
