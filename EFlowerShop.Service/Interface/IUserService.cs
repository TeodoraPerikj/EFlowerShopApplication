using EFlowerShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFlowerShop.Service.Interface
{
    public interface IUserService
    {
        IEnumerable<EFlowerShopApplicationUser> GetAll();
        EFlowerShopApplicationUser Get(string id);
    }
}
