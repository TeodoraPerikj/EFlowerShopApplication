using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFlowerShop.Domain.DomainModels
{
    public class FlowerInShoppingCart : BaseEntity
    {
        public Guid FlowerId { get; set; }
        public Flower Flower { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
