using AutoRentWebDomain.ViewModels.Order;
using BLL.Interfaces.EntityServices;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRentWeb.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IArendatorService arendatorService;
        public OrderController(IOrderService orderService, IArendatorService arendatorService)
        {
            this.orderService = orderService;
            this.arendatorService = arendatorService;
        }

        [HttpGet]
        public IActionResult CreateOrder(int id)
        {
           // var arendators = arendatorService.Get().FirstOrDefault(x=>x.User.Login==User.Identity.Name);
            var orderModel = new CreateOrderViewModel()
            {
                CarId = id,
                Login = User.Identity.Name,
                /*DateStarted=System.DateTime.Now,
                Name=arendators.Name,
                Address=arendators.Adress*/
            };
            return View(orderModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await orderService.Create(model);
                if (response.StatusCode == AutoRentWebDomain.Enum.StatusCode.OK)
                {
                  return Json(new { description = response.Description });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
