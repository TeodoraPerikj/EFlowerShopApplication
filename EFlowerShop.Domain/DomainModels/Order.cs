using EFlowerShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFlowerShop.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public EFlowerShopApplicationUser User { get; set; }

        public virtual ICollection<FlowerInOrder> FlowerInOrders { get; set; }
    }
}
