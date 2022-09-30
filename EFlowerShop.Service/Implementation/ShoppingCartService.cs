using EFlowerShop.Domain.DomainModels;
using EFlowerShop.Domain.DTO;
using EFlowerShop.Repository.Interface;
using EFlowerShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFlowerShop.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<FlowerInOrder> _flowerInOrderRepository;
        private readonly IUserRepository _userRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IUserRepository userRepository, 
            IRepository<Order> orderRepository, IRepository<FlowerInOrder> flowerInOrderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _flowerInOrderRepository = flowerInOrderRepository;
        }
        public bool DeleteFlowerFromSoppingCart(string userId, Guid flowerId)
        {
            if (!string.IsNullOrEmpty(userId) && flowerId != null)
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var itemToDelete = userShoppingCart.FlowerInShoppingCarts.Where(z => z.FlowerId.Equals(flowerId)).FirstOrDefault();

                userShoppingCart.FlowerInShoppingCarts.Remove(itemToDelete);

                this._shoppingCartRepository.Update(userShoppingCart);

                return true;
            }
            return false;
        }

        public ShoppingCartDto GetShoppingCartInfo(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userCard = loggedInUser.UserCart;

                var allFlowers = userCard.FlowerInShoppingCarts.ToList();

                var allFlowerPrices = allFlowers.Select(z => new
                {
                    FlowerPrice = z.Flower.FlowerPrice,
                    Quantity = z.Quantity
                }).ToList();

                double totalPrice = 0.0;

                foreach (var item in allFlowerPrices)
                {
                    totalPrice += item.Quantity * item.FlowerPrice;
                }

                var result = new ShoppingCartDto
                {
                    Flowers = allFlowers,
                    TotalPrice = totalPrice
                };

                return result;
            }
            return new ShoppingCartDto();
        }

        public bool Order(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);
                var userCard = loggedInUser.UserCart;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    UserId = userId
                };

                this._orderRepository.Insert(order);

                List<FlowerInOrder> flowerInOrders = new List<FlowerInOrder>();

                var result = userCard.FlowerInShoppingCarts.Select(z => new FlowerInOrder
                {
                    Id = Guid.NewGuid(),
                    FlowerId = z.Flower.Id,
                    Flower = z.Flower,
                    OrderId = order.Id,
                    Order = order,
                    Quantity = z.Quantity
                }).ToList();

                flowerInOrders.AddRange(result);

                foreach (var item in flowerInOrders)
                {
                    this._flowerInOrderRepository.Insert(item);
                }

                loggedInUser.UserCart.FlowerInShoppingCarts.Clear();

                this._userRepository.Update(loggedInUser);

                return true;
            }

            return false;
        }
    }
}
