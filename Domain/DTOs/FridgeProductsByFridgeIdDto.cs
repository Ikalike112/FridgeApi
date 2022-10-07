using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class FridgeProductsByFridgeIdDto
    {
        public Guid Id { get; set; }
        public ProductsDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
