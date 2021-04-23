using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.Net;
using System.Net.Mail;
using HarvestOnline.Models;

using Microsoft.EntityFrameworkCore;
using HarvestOnline.Data;

using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace HarvestOnline.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckOutController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Mail()
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            return View();
        }

        [HttpPost]
        public IActionResult Mail(Mail record)
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            using (MailMessage mail = new MailMessage("harvestonline888@gmail.com", record.Email))
            {
                mail.Subject = "Order Notification";
                string message = "Hello," + "<br/><br/><br/>" + "Thank you for ordering from Harvest Onine" + "<br/><br/>"
                                         + "Once order has been paid we will begin to process your order " + "<br/><br/><br/>"
                                         + "Order created at " + DateTime.Now.ToString("M/d/yyyy") + "<br/><br/><br/>"
                                         + "Payment Options: " + "<br/>"
                                         + "<b>GCASH :</b> " + "09985892212" + "<br/><br/><br/>"
                                         + "<b>Bank Transfer</b>: " + "<br/>"
                                         + "Account Name: Harvest Online" + "<br/>"
                                         + "Account Number: 2017 2016 1234";
                                         

                mail.Body = message;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.UseDefaultCredentials = false;
                    NetworkCredential NetworkCred = new NetworkCredential("harvestonline888@gmail.com", "Harvest*15");
                    smtp.EnableSsl = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mail);
                    ViewBag.Message = "Confirmation Sent";
                }
            }
            return View();
        }
    }
}
