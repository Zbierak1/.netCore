using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeBudget.Models;
using HomeBudget.Entities;
using Microsoft.AspNetCore.Authorization;

namespace HomeBudget.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext ctx;

        public HomeController(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
