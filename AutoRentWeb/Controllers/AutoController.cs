using BLL.DTO;
using BLL.Interfaces.EntityServices;
using AutoRentWebDomain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoRentWeb.Mappers;
using AutoRentWebDomain.Entity;
using System.Threading.Tasks;
using System.IO;
using AutoRentWebDomain.ViewModels.Auto;
using System;

namespace AutoRentWeb.Controllers
{
    public class AutoController : Controller
    {
        IAutoService<AutoDTO> autoService;
        IUserSrvice userSrvice;

        public AutoController(IAutoService<AutoDTO> autoService, IUserSrvice userSrvice)
        {
            this.autoService = autoService;
            this.userSrvice = userSrvice;
        }
        [HttpGet]
        public IActionResult GetAuto(int id)
        {
            var auto = autoService.GetCar(id);
            if (auto.StatusCode == AutoRentWebDomain.Enum.StatusCode.OK)
            {
                return View(auto.Data);
            }
            return View("Error", $"{auto.Description}");
        }
        [HttpGet]
        public IActionResult GetAutos()
        {

            if (!User.IsInRole("Представитель компании"))
            {
                var autos = autoService.GetAutos();
                if (autos.StatusCode == AutoRentWebDomain.Enum.StatusCode.OK)
                {
                    var autosViewModels = autos.Data.Select(AutoRentWeb.Mappers.AutoMapper.FromDto).ToList();

                    return View(autosViewModels);
                }

                return View("Error", $"{autos.Description}");
            }
            else
            {
                var user = userSrvice.Get().FirstOrDefault(x=>x.Login==User.Identity.Name);
                var autos = user.CompanyDelegate?.Autos;
                if(autos!=null)
                {
                    return View(autos.Select(AutoRentWeb.Mappers.AutoMapper.FromDto).ToList());
                }
                else
                    return View("Error", "В вашей компании нет машин для аренды");


            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await autoService.DeleteCar(id);
            if (response.StatusCode == AutoRentWebDomain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetAutos");
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
                return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Save(AutoViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var companyDelegate = autoService.GetCompanyDelegate(User.Identity.Name);
                viewModel.CompanyDelegatePhone = companyDelegate.PhoneNumber;
                viewModel.CompanyDelegateName = companyDelegate.Name;
                viewModel.CompanyDelegateId = companyDelegate.Id;
                viewModel.TypeCarId = Convert.ToInt32(viewModel.TypeCar);
                if (viewModel.Id == 0)
                {
                    await autoService.Create(viewModel);
                }
                else
                {
                    //await autoService.Edit(viewModel.Id, viewModel);
                }
                return RedirectToAction("GetAutos");
            }
            var errorMessage = ModelState.Values
               .SelectMany(v => v.Errors.Select(x => x.ErrorMessage)).ToList();
            return StatusCode(StatusCodes.Status500InternalServerError, new { errorMessage });
        }
        [HttpPost]
        public JsonResult GetTypes()
        {
            var types = autoService.GetTypes();
            return Json(types.Data);
        }
    }
}
