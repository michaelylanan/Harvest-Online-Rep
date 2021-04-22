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
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            ApplicationUser user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == _userManager.GetUserId(HttpContext.User));
            var list = _context.Customers.Where(c => c.ApplicationUser == user).ToList();
            return View(list);
        }

        public IActionResult IndexAddress()
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            ApplicationUser user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == _userManager.GetUserId(HttpContext.User));
            var latestCId = _context.Customers.FirstOrDefault(c => c.ApplicationUser == user).CustomerId;
            Customer cust = _context.Customers.FirstOrDefault(c => c.CustomerId == latestCId);

            var list = _context.Addresses.Where(c => c.Customer == cust).ToList();
            return View(list);
        }
        public IActionResult Home()
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            return View();
        }
        public IActionResult CreateProfile()
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            return View();
        }

        [HttpPost]
        public IActionResult CreateProfile(Customer record)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == _userManager.GetUserId(HttpContext.User));

            var check = _context.Customers.FirstOrDefault(s => s.ApplicationUser == user);

            var customer = new Customer();
            if(check == null)
            {
                customer.ApplicationUser = user;
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
            else
            {
                return RedirectToAction("Index");
            }
           
        }
        public IActionResult CreateAddress()
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            return View();
        }

        [HttpPost]
        public IActionResult CreateAddress(Address record)
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            ApplicationUser user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == _userManager.GetUserId(HttpContext.User));

            // this retrieves the foreign key id from customer table
            var latestCId = _context.Customers.FirstOrDefault(c => c.ApplicationUser == user).CustomerId;
            Customer cust = _context.Customers.FirstOrDefault(c => c.CustomerId == latestCId);

            var address = new Address();

            address.Customer = cust;
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

            var address = _context.Addresses.Where(i => i.AddressId == id).SingleOrDefault();
            if (address == null)
            {
                return RedirectToAction("IndexAddress");
            }

            _context.Addresses.Remove(address);
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

        public IActionResult Help()
        {
            ViewBag.userId = _userManager.GetUserName(HttpContext.User);
            return View();
        }

    }
}
