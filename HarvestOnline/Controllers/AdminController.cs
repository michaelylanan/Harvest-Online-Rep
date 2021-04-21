using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using HarvestOnline.Data;
using HarvestOnline.Models;

using System.Security.Cryptography;
using System.Text;

using System.IO;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace HarvestOnline.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();        
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register (AdminUser user)
        {
            if(ModelState.IsValid)
            {
                var check = _context.AdminUsers.FirstOrDefault(s => s.Email == user.Email);

                if (check == null )
                {
                    user.Password = GetMD5(user.Password);

                    _context.AdminUsers.Add(user);
                    _context.SaveChanges();

                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    string msg = "User already Exist!";
                    TempData["Error"] = msg;
                    return RedirectToAction("Register");
                }
            }
            return View();          
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password, AdminUser user)
        {         
            if (ModelState.IsValid)
            {
                var hashPassword = GetMD5(password);

                var data = _context.AdminUsers.Where(s => s.Email.Equals(email) && s.Password.Equals(hashPassword)).ToList();
                AdminUser admin = new AdminUser();

                admin.Email = email;
                admin.Password = password;

                if (data.Count() > 0)
                {
                    user.Email = data.FirstOrDefault().Email;
                    user.Password = data.FirstOrDefault().Password;

                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    string msg = "Incorrect Login Credentials!";
                    TempData["Error"] = msg;
                    return RedirectToAction("Login");
                }
            }         
            return View();
        }

        public static string GetMD5 (string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for(int i =0; i <targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }

     
    }
}
