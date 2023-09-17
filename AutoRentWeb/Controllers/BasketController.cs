using BLL.Interfaces.EntityServices;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRentWeb.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;

        public BasketController (IBasketService basketService)
        {
            this.basketService= basketService;
        }
        public async Task<IActionResult> Detail()
        {
            var response = await basketService.GetItems(User.Identity.Name);
            var response2 = await basketService.GetItems(User.Identity.Name);
            if (response2.StatusCode == AutoRentWebDomain.Enum.StatusCode.OK)
            {
                return View(response2.Data.ToList());
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> GetItem(int id)
        {
            var response = await basketService.GetItem(User.Identity.Name, id);
            if (response.StatusCode == AutoRentWebDomain.Enum.StatusCode.OK)
            {
                return PartialView(response.Data);
            }
            return RedirectToAction("Index", "Home");
        }


    }
}
