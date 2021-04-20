using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.Net;
using System.Net.Mail;
using HarvestOnline.Models;

namespace HarvestOnline.Controllers
{
    public class CheckOutController : Controller
    {
        public IActionResult Page(String ShippingFee)
        {
            if(ShippingFee == "NCR")
            {
                ViewBag.ShippingFee = 60;
                 return View();
            }
            else if(ShippingFee == "Central Luzon")
            {
                ViewBag.ShippingFee = 150;
                return View();
            }
            else
            {
                ViewBag.ShippingFee = 140;
                return View();
            }
        }
        public IActionResult Mail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Mail(Mail record)
        {
            using (MailMessage mail = new MailMessage("harvestonline888@gmail.com", record.Email))
            {
                mail.Subject = "Order Notification";
                string message = "Hello," + "<br/><br/><br/>" + "Thank you for ordering from Harvest Onine"+ "<br/><br/>"
                                         + "Your order is currently being processed " + "<br/><br/><br/>"
                                         + "Order created at " + DateTime.Now.ToString("M/d/yyyy");

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
                    ViewBag.Message = "Inquiry Sent";
                }
            }
             return View();
        }

              
        

    }
}
