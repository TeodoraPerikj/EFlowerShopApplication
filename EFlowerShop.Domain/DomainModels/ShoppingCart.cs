using EFlowerShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFlowerShop.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public string OwnerId { get; set; }
        public virtual EFlowerShopApplicationUser Owner { get; set; }

        public virtual ICollection<FlowerInShoppingCart> FlowerInShoppingCarts { get; set; }
    }
}
