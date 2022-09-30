using EFlowerShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFlowerShop.Domain.DTO
{
    public class AddToShoppingCartDto
    {
            public Flower SelectedFlower { get; set; }
            public Guid SelectedFlowerId { get; set; }
            public int Quantity { get; set; }
 
    }
}
