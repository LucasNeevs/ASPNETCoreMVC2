using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Site01.Models;
using Microsoft.AspNetCore.Http;

namespace Site01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([FromForm]User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Email == "lucasneves.dev@gmail.com" && user.Password == "pass123")
                {
                    HttpContext.Session.SetString("Login", "true");
                    return RedirectToAction("Index", "Word");
                }
                else
                {
                    ViewBag.Message = "Data is invalid";

                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
