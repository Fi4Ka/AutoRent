using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces.EntityServices;
using System.Threading.Tasks;
using AutoRentWebDomain.ViewModels.User;
using System.Linq;
using AutoRentWebDomain.ViewModels.CompanyDelegate;

namespace AutoRentWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserSrvice _userService;

        public UserController(IUserSrvice userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            if (response.StatusCode == AutoRentWebDomain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _userService.DeleteUser(id);
            if (response.StatusCode == AutoRentWebDomain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetUsers");
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Save() => PartialView();

        [HttpPost]
        public async Task<IActionResult> Save(CompanyDelegateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.CreateDelegate(model);
                if (response.StatusCode == AutoRentWebDomain.Enum.StatusCode.OK)
                {
                    return Json(new { description = response.Description });
                }
                return BadRequest(new { errorMessage = response.Description });
            }
            var errorMessage = ModelState.Values
                .SelectMany(v => v.Errors.Select(x => x.ErrorMessage)).ToList();
            return StatusCode(StatusCodes.Status500InternalServerError, new { errorMessage });
        }

    }
}
