using System;

namespace Application.Contracts.Fridges
{
    public class FridgeByIdDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public Guid FridgeModelId { get; set; }
    }
}
