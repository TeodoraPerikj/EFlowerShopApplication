using EFlowerShop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFlowerShop.Service.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto GetShoppingCartInfo(string userId);
        bool DeleteFlowerFromSoppingCart(string userId, Guid flowerId);
        bool Order(string userId);
    }
}
