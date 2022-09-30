using EFlowerShop.Domain.Identity;
using EFlowerShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFlowerShop.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<EFlowerShopApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<EFlowerShopApplicationUser>();
        }
        public void Delete(EFlowerShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            context.SaveChanges();
        }

        public EFlowerShopApplicationUser Get(string id)
        {
            return entities
                     .Include(z => z.UserCart)
                     .Include("UserCart.FlowerInShoppingCarts")
                     .Include("UserCart.FlowerInShoppingCarts.Flower")
                     .SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<EFlowerShopApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(EFlowerShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(EFlowerShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
