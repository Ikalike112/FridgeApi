using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Products
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }
        public ICollection<FridgeProducts> FridgeProducts { get; set; }
    }
}
