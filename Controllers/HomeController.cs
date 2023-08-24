using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Models.Authentication;
using TaskManagement.Models.Data;

namespace TaskManagement.Controllers
{

    public class HomeController : Controller
    {

        Context context = new Context();

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddPersonnel()
        {
            ViewBag.dep = new SelectList(context.Departments, "Id", "DepName");
            ViewBag.perGet = context.Personnels.Include(x => x.Department).ToList();
            return View("AddPersonnel");
        }
        [HttpPost]
        public IActionResult AddPersonnel(Personnel per)
        {
            if (!ModelState.IsValid)
            {
                var personnel = context.Departments.Where(x => x.Id == per.Department.Id).FirstOrDefault();
                per.Department = personnel;
                context.Personnels.Add(per);
                context.SaveChanges();

                return RedirectToAction("AddPersonnel");
            }
            else
            {

                return View("Index");
            }
        }


        [HttpGet]
        public IActionResult EditPersonnel(int id)
        {
            ViewBag.dep = new SelectList(context.Departments, "Id", "DepName");
            var per = context.Personnels.Find(id);

            return View("EditPersonnel", per);
        }

        [HttpPost]
        public IActionResult EditPersonnel(Personnel personnel)
        {
            if (!ModelState.IsValid)
            {

                var perUp = context.Departments.Where(x => x.Id == personnel.Department.Id).FirstOrDefault();
                personnel.Department = perUp;

                var up = context.Personnels.Find(personnel.Id);

                up.NameSurname = personnel.NameSurname;
                up.Phone = personnel.Phone;
                up.Email = personnel.Email;
                up.Department = personnel.Department;


                context.SaveChanges();

                return RedirectToAction("AddPersonnel");
            }
            else
            {
                return View();
            }
        }

        public IActionResult RemovePersonnel(int id)
        {
            var rp = context.Personnels.Find(id);
            context.Personnels.Remove(rp);
            context.SaveChanges();

            return RedirectToAction("AddPersonnel");
        }

        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.con = new SelectList(context.Conditions, "Id", "CondName");
            ViewBag.BTPer = new SelectList(context.BTPersonnels, "Id", "NameSurname");
            ViewBag.per = new SelectList(context.Personnels, "Id", "NameSurname");
            ViewBag.ser = context.Services.Include(x => x.Condition).Include(x => x.BTPersonnel).Include(x => x.Personnel).ToList();
            return View("AddService");
        }
        [HttpPost]
        public IActionResult AddService(Service ser)
        {
            if (!ModelState.IsValid)
            {
                var Con = context.Conditions.Where(x => x.Id == ser.Condition.Id).FirstOrDefault();
                var BTPer = context.BTPersonnels.Where(x => x.Id == ser.BTPersonnel.Id).FirstOrDefault();
                var Per = context.Personnels.Where(x => x.Id == ser.Personnel.Id).FirstOrDefault();
                ser.Condition = Con;
                ser.BTPersonnel = BTPer;
                ser.Personnel = Per;

                context.Services.Add(ser);
                context.SaveChanges();

                return RedirectToAction("AddService");
            }
            else
            {

                return View("Index");
            }
        }
        public IActionResult RemoveService(int id)
        {
            var rd = context.Services.Find(id);
            context.Services.Remove(rd);
            context.SaveChanges();

            return RedirectToAction("AddService");
        }



    }
}