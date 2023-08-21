using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using TaskManagement.Models;


namespace TaskManagement.Controllers
{
    
    public class HomeController : Controller
    {
       
        Context context = new Context();
        
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
            ViewBag.person = context.Personnels.ToList();
            return View("Admin");
        }
        [HttpPost]
        public IActionResult AddPersonnel(Personnel per)
        {
            var ekle = context.Personnels.Add(per);
            context.SaveChanges();
            return RedirectToAction("Admin",ekle);

            // return RedirectToAction("AddDepartment", ekle);  partiala yönlendirmek için
            // @await Html.PartialAsync("_EditDepartmentPartial", item)
        }

        [HttpGet]
        public IActionResult Admin()
        {
            ViewBag.person = new SelectList(context.Personnels,"Id", "NameSurname");
            ViewBag.con = new SelectList(context.Conditions, "Id", "CondName");
            ViewBag.BTPerson = new SelectList(context.BTPersonnels, "Id", "NameSurname");
            ViewBag.ServiceGet = context.Services.Include(x=>x.Personnel).ToList();
            
            return View();
        }


        [HttpPost]
        public IActionResult Admin(Service ser)
        {

            var pers = context.Personnels.Where(x => x.Id == ser.Personnel.Id).FirstOrDefault();
            var cond = context.Conditions.Where(x => x.Id == ser.Condition.Id).FirstOrDefault();
            var BTPers = context.BTPersonnels.Where(x => x.Id == ser.BTPersonnel.Id).FirstOrDefault();
            if(pers == null)
            {

            }
            ser.Personnel = pers;
            ser.Condition = cond;
            ser.BTPersonnel = BTPers;
            context.Services.Add(ser);
            context.SaveChanges();
          
            return View("Admin");
        }

 
    }
}