using AutoRentWeb.DAL.Interfaces;
using AutoRentWebDomain.ViewModels.Arendator;
using BLL.Interfaces.EntityServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AutoRentWeb.Controllers
{
    public class ArendatorController : Controller
    {
        private readonly IArendatorService arendatorService;
        public ArendatorController(IArendatorService arendatorService)
        {
            this.arendatorService = arendatorService;
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProfileViewModal model)
        {
            if (ModelState.IsValid)
            {
                var response = await arendatorService.Update(model);
                if (response.StatusCode == AutoRentWebDomain.Enum.StatusCode.OK)
                {
                    return Json(new { description = response.Description });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        public async Task<IActionResult> Detail()
        {
            var userName = User.Identity.Name;
            var response = await arendatorService.GetProfile(userName);
            if (response.StatusCode == AutoRentWebDomain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View();
        }
    }
}
