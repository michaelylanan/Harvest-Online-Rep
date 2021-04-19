using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
