using EFlowerShop.Domain.DomainModels;
using EFlowerShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFlowerShop.Domain.DTO
{
    public class ViewModel
    {
        public List<Flower> Flowers { get; set; }
        public string Role { get; set; }
    }
}
