using EFlowerShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFlowerShop.Service.Interface
{
    public interface IOrderService
    {
        public List<Order> GetAllOrders();
        public Order GetOrderDetails(BaseEntity model);
    }
}
