using EFlowerShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFlowerShop.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<FlowerInShoppingCart> Flowers { get; set; }

        public double TotalPrice { get; set; }
    }
}
