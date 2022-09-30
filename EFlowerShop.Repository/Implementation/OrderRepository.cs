using EFlowerShop.Domain.DomainModels;
using EFlowerShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFlowerShop.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> GetAllOrders()
        {
            return entities
                .Include(z => z.User)
                .Include(z => z.FlowerInOrders)
                .Include("FlowerInOrders.Flower")
                .ToListAsync().Result;
        }
        public Order GetOrderDetails(BaseEntity model)
        {
            return entities
              .Include(z => z.User)
              .Include(z => z.FlowerInOrders)
              .Include("FlowerInOrders.Flower")
              .SingleOrDefaultAsync(z => z.Id == model.Id).Result;
        }
    }
}
