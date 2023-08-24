using Microsoft.AspNetCore.Mvc;
using TaskManagement.Models.Authentication;
using TaskManagement.Models.Data;


namespace TaskManagement.Controllers
{
    public class AuthenticationController : Controller
    {
        Context context = new Context();

        [HttpGet]
        public IActionResult Register(int id = 0)
        {
            Register register = new Register();
            return View(register);
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (context.Register.Any(x => x.Email == register.Email))
            {
                ViewBag.Duplicate = "Email already exist!";
                TempData["Failed"] = " ";
                return View(register);
            }
            else if (register.Password != register.PasswordConfirmation)
            {
                ViewBag.Duplicate = "Passwords not same!";
                TempData["Failed"] = " ";
                return View(register);

            }
            else
            {
                context.Register.Add(register);
                context.SaveChanges();
                ViewBag.Success = register.NameSurname.ToUpper() +" "+ "Registration Successfull!";
                TempData["Success"] = " ";
                return View("Register");
            }

        }

        [HttpGet]
        public IActionResult Login()
        {
            Register register = new Register();
            return View(register);
        }
        [HttpPost]
        public IActionResult Login(Register login)
        {
            var log = context.Register.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
            if (log == null)
            {
                ViewBag.Reg = "User not exist!";
                TempData["Reg"] = " ";
                return View("Login");
            }
            else
            {
                ViewBag.Reg = "Login Successfull";
                TempData["Reg"] = " ";
                ViewBag.message = login.NameSurname + " " + " Welcome ";
                return RedirectToAction("Index", "Home");

            }

        }
    }
}
