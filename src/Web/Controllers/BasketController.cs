﻿using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketViewModelService _basketViewModelService;

        public BasketController(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = await _basketViewModelService.GetBasketViewModelAsync();
            return View(vm);
        }

        public async Task<IActionResult> AddToBasket(int productId, int quantity = 1)
        {
            var vm = await _basketViewModelService.AddItemToBasketAsync(productId, quantity);
            return Json(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Empty()
        {
            await _basketViewModelService.EmptyBasketAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int productId)
        {
            await _basketViewModelService.DeleteBasketItemAsync(productId);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([ModelBinder(Name = "quantities")] Dictionary<int, int> quantities)
        {
            await _basketViewModelService.UpdateBasketAsync(quantities);
            return RedirectToAction(nameof(Index));
        }
    }
}
