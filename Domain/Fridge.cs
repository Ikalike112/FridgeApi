using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Fridge
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string OwnerName { get; set; }
        [Required]
        public Guid FridgeModelId { get; set; }
        public FridgeModel FridgeModel { get; set; }
        public ICollection<FridgeProducts> FridgeProducts { get; set; }
    }
}
