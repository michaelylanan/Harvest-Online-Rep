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
            using (MailMessage mail = new MailMessage("miguelryan.magallanes@benilde.edu.ph", record.Email))
            {
                mail.Subject = "Order Notification";
                string message = "Hello";

                mail.Body = message;
                mail.IsBodyHtml = true;

    
            }
                return View();
        }

    }
}
