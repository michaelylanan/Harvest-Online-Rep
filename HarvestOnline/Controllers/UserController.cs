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
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Customers.Include(c => c.ApplicationUser).ToList();
            return View(list);
        }
        public IActionResult Home()
        {
            return View();
        }
        // Create User Profile ----------------------------------------
        public IActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProfile(Customer record)
        {
            var customer = new Customer();

            customer.FullName = record.FullName;
            customer.PhoneNumber = record.FullName;
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

            return RedirectToAction("Index");
        }
        //------------------------------------------------------------------------

        // Profile Customer Edit-------------------------------------------------
        public IActionResult EditProfile(int? id)
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

            return RedirectToAction("Index");
        }
        //---------------------------------------------------------------

        //Edit Address -----------------------------------
        public IActionResult EditAddress(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var address = _context.Addresses.Where(i => i.AddressId == id).SingleOrDefault();
            if (address == null)
            {
                return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }



    }
}
