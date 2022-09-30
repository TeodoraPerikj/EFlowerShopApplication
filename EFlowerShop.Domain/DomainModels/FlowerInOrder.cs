using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFlowerShop.Domain.DomainModels
{
    public class FlowerInOrder : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid FlowerId { get; set; }
        public Flower Flower { get; set; }

        public int Quantity { get; set; }
    }
}
