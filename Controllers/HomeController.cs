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
        
        public IActionResult Admin()
        {
            return View();
        }
        
            public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddPersonnel()
        {
            ViewBag.dep = context.Personnels.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddPersonnel(Personnel per)
        {
            var ekle = context.Personnels.Add(per);
            context.SaveChanges();
            return RedirectToAction("Admin");

            // return RedirectToAction("AddDepartment", ekle);  partiala yönlendirmek için
            // @await Html.PartialAsync("_EditDepartmentPartial", item)
        }

        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.personnel = new SelectList(context.Personnels, "Id", "NameSurname");
            ViewBag.con = new SelectList(context.Conditions, "Id", "CondName");
            ViewBag.BTPerson = new SelectList(context.BTPersonnels, "Id", "NameSurname");
            ViewBag.ServiceGet = context.Services.Include(x => x.Personnel).Include(x => x.Condition).Include(x=>x.BTPersonnel).ToList();
            return View("Admin");
        }


        [HttpPost]
        public IActionResult AddService(Service ser)
        {
            if (!ModelState.IsValid)
            {

                var service = context.Personnels.Where(x => x.Id == ser.Personnel.Id).FirstOrDefault();
                ser.Personnel = service;
                context.Services.Add(ser);
                context.SaveChanges();
            
                return RedirectToAction("Admin");
            }
            else
            {
                return View("Admin");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}