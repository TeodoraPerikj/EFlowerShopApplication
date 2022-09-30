using EFlowerShop.Domain.DomainModels;
using EFlowerShop.Repository.Interface;
using EFlowerShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFlowerShop.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> GetAllOrders()
        {
            return this._orderRepository.GetAllOrders();
        }

        public Order GetOrderDetails(BaseEntity model)
        {
            return this._orderRepository.GetOrderDetails(model);
        }
    }
}
