using System;

namespace Application.Contracts.FridgeModels
{
    public class FridgeModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
    }
}
