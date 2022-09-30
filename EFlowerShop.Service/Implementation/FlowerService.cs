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
    public class FlowerService : IFlowerService
    {
        private readonly IRepository<Flower> _flowerRepository;
        private readonly IRepository<FlowerInShoppingCart> _flowerInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public FlowerService(IRepository<Flower> flowerRepository, 
            IRepository<FlowerInShoppingCart> flowerInShoppingCartRepository, IUserRepository userRepository)
        {
            _flowerRepository = flowerRepository;
            _flowerInShoppingCartRepository = flowerInShoppingCartRepository;
            _userRepository = userRepository;
        }
        public bool AddToShoppingCart(AddToShoppingCartDto item, string userId)
        {
            var user = this._userRepository.Get(userId);

            var userShoppingCard = user.UserCart;

            if (item.SelectedFlowerId != null && userShoppingCard != null)
            {
                var flower = this.GetDetailsForFlower(item.SelectedFlowerId);

                if (flower != null)
                {
                    FlowerInShoppingCart itemToAdd = new FlowerInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        Flower = flower,
                        FlowerId = flower.Id,
                        ShoppingCart = userShoppingCard,
                        ShoppingCartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    this._flowerInShoppingCartRepository.Insert(itemToAdd);
                    return true;
                }
                return false;
            }
            return false;
        }

        public void CreateNewFlower(Flower f)
        {
            this._flowerRepository.Insert(f);
        }

        public void DeleteFlower(Guid id)
        {
            var flower = this.GetDetailsForFlower(id);
            this._flowerRepository.Delete(flower);
        }

        public List<Flower> GetAllFlowers()
        {
            return this._flowerRepository.GetAll().ToList();
        }

        public Flower GetDetailsForFlower(Guid? id)
        {
            return this._flowerRepository.Get(id);
        }

        public AddToShoppingCartDto GetShoppingCartInfo(Guid? id)
        {
            var flower = this.GetDetailsForFlower(id);
            AddToShoppingCartDto model = new AddToShoppingCartDto
            {
                SelectedFlower = flower,
                SelectedFlowerId = flower.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdateExistingFlower(Flower f)
        {
            this._flowerRepository.Update(f);
        }
    }
}
