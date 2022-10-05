using EFlowerShop.Domain.Identity;
using EFlowerShop.Repository.Interface;
using EFlowerShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFlowerShop.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public EFlowerShopApplicationUser Get(string id)
        {
            return this._userRepository.Get(id);
        }

        public IEnumerable<EFlowerShopApplicationUser> GetAll()
        {
            return this._userRepository.GetAll();
        }
    }
}
