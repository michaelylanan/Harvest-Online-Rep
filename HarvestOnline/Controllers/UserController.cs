using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using HarvestOnline.Data;
using HarvestOnline.Models;

using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace HarvestOnline.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(ApplicationDbContext context, UserManager<ApplicationUser>userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var list = _context.Customers.Include(c => c.ApplicationUser).ToList();
            return View(list);
        }

        public IActionResult IndexAddress()
        {
             ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            var list = _context.Addresses.Include(c => c.Customer).ToList();
            return View(list);
        }
        public IActionResult Home(String searchby, String search)
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            return View();
        }
        // Create User Profile ----------------------------------------
        public IActionResult CreateProfile()
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            return View();
        }

        [HttpPost]
        public IActionResult CreateProfile(int id, Customer record, ApplicationUser user)
        {
               
            var customer = new Customer();
            string userId = _userManager.GetUserId(HttpContext.User);

            customer.FullName = record.FullName;
            customer.PhoneNumber = record.PhoneNumber;
            customer.ProfileName = record.ProfileName;
            customer.Gender = record.Gender;
            customer.Birthday = record.Birthday;
            customer.Age = record.Age;

            _context.Customers.Add(customer);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        //------------------------------------------------------------------------

        //Create User Address-------------------------------------------------
        public IActionResult CreateAddress()
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            return View();
        }

        [HttpPost]
        public IActionResult CreateAddress(Address record)
        {
            var address = new Address();
            address.PostalCode = record.PostalCode;
            address.Region = record.Region;
            address.Province = record.Province;
            address.City = record.City;
            address.Barangay = record.Barangay;
            address.BuildingNo = record.BuildingNo;

            _context.Addresses.Add(address);
            _context.SaveChanges();

            return RedirectToAction("IndexAddress");
        }
        //------------------------------------------------------------------------

        // Profile Customer Edit-------------------------------------------------
        public IActionResult EditProfile(int? id)
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var customer = _context.Customers.Where(i => i.CustomerId == id).SingleOrDefault();
            if (customer == null)
            {
                return RedirectToAction("IndexAddress");
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult EditProfile (int? id, Customer record)
        {
            var customer = _context.Customers.Where(i => i.CustomerId == id).SingleOrDefault();
            customer.FullName = record.FullName;
            customer.PhoneNumber = record.PhoneNumber;
            customer.ProfileName = record.ProfileName;
            customer.Gender = record.Gender;
            customer.Birthday = record.Birthday;
            customer.Age = record.Age;

            _context.Customers.Update(customer);
            _context.SaveChanges();

            return RedirectToAction("IndexAddress");
        }
        //---------------------------------------------------------------

        //Edit Address -----------------------------------
        public IActionResult EditAddress(int? id)
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            if (id == null)
            {
                return RedirectToAction("IndexAddress");
            }

            var address = _context.Addresses.Where(i => i.AddressId == id).SingleOrDefault();
            if (address == null)
            {
                return RedirectToAction("IndexAddress");
            }
            return View(address);
        }

        [HttpPost]
        public IActionResult EditAddress(int? id, Address record)
        {
            var address = _context.Addresses.Where(i => i.AddressId == id).SingleOrDefault();
            address.PostalCode = record.PostalCode;
            address.Region = record.Region;
            address.Province = record.Province;
            address.City = record.City;
            address.Barangay = record.Barangay;
            address.BuildingNo = record.BuildingNo;

            _context.Addresses.Update(address);
            _context.SaveChanges();

            return RedirectToAction("IndexAddress");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var customer = _context.Customers.Where(i => i.CustomerId == id).SingleOrDefault();
            if (customer == null)
            {
                return RedirectToAction("Index");
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteAddress(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("IndexAddress");
            }

            var customer = _context.Customers.Where(i => i.CustomerId == id).SingleOrDefault();
            if (customer == null)
            {
                return RedirectToAction("IndexAddress");
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("IndexAddress");
        }

        public IActionResult DisplayView(String searchby, String search)
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            var list = _context.Products.ToList();
            if (searchby == "ItemName" && search != null)
            {
                return View(list.Where(x => x.ItemName.Contains(search)).ToList());
            }           
            else
            {
                return View(list);
            }
        }


        public IActionResult About()
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            return View();
        }

        public IActionResult Farmers()
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            return View();
        }

    }
}
