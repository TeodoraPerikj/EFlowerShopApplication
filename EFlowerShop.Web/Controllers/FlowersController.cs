using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using EFlowerShop.Repository;
using EFlowerShop.Domain.DomainModels;
using EFlowerShop.Domain.DTO;
using EFlowerShop.Service.Interface;

namespace EFlowerShop.Web.Controllers
{
    public class FlowersController : Controller
    {
        private readonly IFlowerService _flowerService;

        public FlowersController(IFlowerService flowerService)
        {
            _flowerService = flowerService;
        }

        // GET: Flowers
        public IActionResult Index()
        {
            var allFlowers = this._flowerService.GetAllFlowers();

            return View(allFlowers);
        }

        // GET: Flowers/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower = this._flowerService.GetDetailsForFlower(id);

            if (flower == null)
            {
                return NotFound();
            }

            return View(flower);
        }

        // GET: Flowers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flowers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FlowerName,FlowerImage,FlowerDescription,FlowerPrice")] Flower flower)
        {
            if (ModelState.IsValid)
            {
                this._flowerService.CreateNewFlower(flower);
                return RedirectToAction(nameof(Index));
            }
            return View(flower);
        }

        // GET: Flowers/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower = this._flowerService.GetDetailsForFlower(id);
            if (flower == null)
            {
                return NotFound();
            }
            return View(flower);
        }

        // POST: Flowers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,FlowerName,FlowerImage,FlowerDescription,FlowerPrice")] Flower flower)
        {
            if (id != flower.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._flowerService.UpdateExistingFlower(flower);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlowerExists(flower.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flower);
        }

        // GET: Flowers/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flower = this._flowerService.GetDetailsForFlower(id);
                
            if (flower == null)
            {
                return NotFound();
            }

            return View(flower);
        }

        // POST: Flowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._flowerService.DeleteFlower(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddFlowerToCart(Guid id)
        {
            var result = this._flowerService.GetShoppingCartInfo(id);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFlowerToCart(AddToShoppingCartDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._flowerService.AddToShoppingCart(model, userId);

            if (result)
            { 
                return RedirectToAction("Index", "Flowers");
            }
            return View(model);
        }
        private bool FlowerExists(Guid id)
        {
            return this._flowerService.GetDetailsForFlower(id) != null;
        }
    }
}
