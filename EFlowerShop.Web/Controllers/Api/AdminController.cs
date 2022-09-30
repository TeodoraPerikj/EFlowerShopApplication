using EFlowerShop.Domain.DomainModels;
using EFlowerShop.Domain.Identity;
using EFlowerShop.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFlowerShop.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<EFlowerShopApplicationUser> _userManager;
        public AdminController(IOrderService orderService, UserManager<EFlowerShopApplicationUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetOrders()
        {
            var result = this._orderService.GetAllOrders();
            return result;
        }

        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity model)
        {
            var result = this._orderService.GetOrderDetails(model);
            return result;
        }

        [HttpPost("[action]")]
        public bool ImportAllUsers(List<UserRegistrationDto> model)
        {
            bool status = true;
            foreach (var item in model)
            {
                var userCheck = _userManager.FindByEmailAsync(item.Email).Result;
                if (userCheck == null)
                {
                    var user = new EFlowerShopApplicationUser
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        UserName = item.Email,
                        NormalizedUserName = item.Email,
                        Email = item.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        UserCart = new ShoppingCart()
                    };
                    var result = _userManager.CreateAsync(user, item.Password).Result;

                    status = status & result.Succeeded;
                }
                else
                {
                    continue;
                }
            }

            return status;
        }

        [HttpGet("[action]")]
        public List<EFlowerShopApplicationUser> GetAllUsers()
        {
            List<EFlowerShopApplicationUser> users = _userManager.Users.ToList();
            return users;
        }

        [HttpPost("[action]")]
        public async Task<EFlowerShopApplicationUser> GetDetailsForUser([FromQuery(Name = "email")] string email)
        {
            EFlowerShopApplicationUser user = await _userManager.FindByEmailAsync(email);

            return user;
        }
        [HttpPost("[action]")]
        public async Task<bool> Edit([FromQuery(Name = "email")] string email, [FromQuery(Name = "role")] string role)
        {

            EFlowerShopApplicationUser user = await _userManager.FindByEmailAsync(email);

            user.Email = email;
            user.UserName = email;
            user.Role = role;

            await _userManager.UpdateAsync(user);

            return true;
        }
    }
}
