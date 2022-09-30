using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFlowerShop.Domain.DomainModels
{
    public class Flower : BaseEntity
    {
        [Required]
        public string FlowerName { get; set; }
        [Required]
        public string FlowerImage { get; set; }
        [Required]
        public string FlowerDescription { get; set; }
        [Required]
        public double FlowerPrice { get; set; }

        public virtual ICollection<FlowerInShoppingCart> FlowerInShoppingCarts { get; set; }
        public virtual ICollection<FlowerInOrder> Orders { get; set; }
}
}
