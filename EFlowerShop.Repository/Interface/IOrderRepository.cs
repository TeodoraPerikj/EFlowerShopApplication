using EFlowerShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFlowerShop.Repository.Interface
{
    public interface IOrderRepository
    {
        public List<Order> GetAllOrders();
        public Order GetOrderDetails(BaseEntity model);
    }
}
