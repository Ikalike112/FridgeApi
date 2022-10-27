using Application.Contracts.FridgeProducts;
using System.Collections.Generic;

namespace Application.Contracts.Fridges
{
    public class FridgeForCreateDto : FridgeForManipulateDto
    {
        public IEnumerable<FridgeProductToCreateFromFridgeDto>? FridgeProducts { get; set; }
    }
}
