using EFlowerShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFlowerShop.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<EFlowerShopApplicationUser> GetAll();
        EFlowerShopApplicationUser Get(string id);
        void Insert(EFlowerShopApplicationUser entity);
        void Update(EFlowerShopApplicationUser entity);
        void Delete(EFlowerShopApplicationUser entity);
    }
}
