using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site01.Models;
using Site01.Library.Mail;

namespace Site01.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Contact = new Contact();
     
            return View("Contact");
        }

        public IActionResult Receive([FromForm] Contact contact)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Contact = new Contact();

                SendMail.SendContactMessage(contact);

                ViewBag.Message = "Message sent with success!";

                return View("Contact");
            }
            else
            {
                ViewBag.Contact = contact;

                return View("Contact");
            }
        }
    }
}