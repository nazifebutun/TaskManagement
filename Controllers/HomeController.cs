using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TaskManagement.Models;


namespace TaskManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        Context context = new Context();
        [HttpGet]
        public IActionResult Admin()
        {
            ViewBag.condition = context.Conditions.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CondName,
            });

            ViewBag.BTPer = context.BTPersonnels.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.NameSurname,
            });

            ViewBag.Per = context.Personnels.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.NameSurname,
                
            });
            ViewBag.Service = context.Services.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.ServiceName,

            });
            Condition condition = new Condition();
            ViewBag.ser = context.Services.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Admin(Service service)
        {
            var add = context.Services.Add(service);

            context.SaveChanges();
            return RedirectToAction("Admin");
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