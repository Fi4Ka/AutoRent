using BLL.Interfaces.EntityServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRentWeb.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IStatisticService statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }
        public ActionResult Index()
        {
            try
            {
                ViewBag.d1 = statisticService.GetRentCount(User.Identity.Name);
                ViewBag.d2 = statisticService.GetAllRentCost(User.Identity.Name);
                ViewBag.d3 = statisticService.GetMostRentAuto(User.Identity.Name);
                return View();
            }
            catch
            {
                return View("Error", "что-то пошло не так...((");
            }
        }

        // GET: StatisticController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StatisticController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatisticController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatisticController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StatisticController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatisticController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StatisticController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
