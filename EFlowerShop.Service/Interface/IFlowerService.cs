using EFlowerShop.Domain.DomainModels;
using EFlowerShop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFlowerShop.Service.Interface
{
    public interface IFlowerService
    {
        List<Flower> GetAllFlowers();
        Flower GetDetailsForFlower(Guid? id);
        void CreateNewFlower(Flower f);
        void UpdateExistingFlower(Flower f);
        AddToShoppingCartDto GetShoppingCartInfo(Guid? id);
        void DeleteFlower(Guid id);
        bool AddToShoppingCart(AddToShoppingCartDto item, string userId);
    }
}
