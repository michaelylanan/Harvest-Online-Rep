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


namespace HarvestOnline.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;            
        public ProductController(ApplicationDbContext context)
        {
            _context = context;        
        }

        public IActionResult Index()
        {
            var list = _context.Products.ToList();
            return View(list);
        }

        public IActionResult DisplayView()
        {
            var list = _context.Products.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product record, HttpPostAttribute httpPostedFileBase)
        {

            var product = new Product();
            product.ItemName = record.ItemName;
            product.Supplier = record.Supplier;
            product.ItemSellingQuanity = record.ItemSellingQuanity;
            product.ItemUnit = record.ItemUnit;
            product.Price = record.Price;
            product.ItemPortionPrice = record.ItemPortionPrice;
            product.ImagePath = record.ImagePath;
            product.DateAdded = DateTime.Now;

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit (int? id)
        {
            if (id==null)
            {
                return RedirectToAction("Index");
            }

            var product = _context.Products.Where(i => i.ItemId == id).SingleOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit (int? id, Product record)
        {
            var product= _context.Products.Where(i => i.ItemId == id).SingleOrDefault();
            product.ItemName = record.ItemName;
            product.Supplier = record.Supplier;
            product.ItemSellingQuanity = record.ItemSellingQuanity;
            product.ItemUnit = record.ItemUnit;
            product.Price = record.Price;
            product.ItemPortionPrice = record.ItemPortionPrice;
            product.ImagePath = record.ImagePath;
            product.DateModified = DateTime.Now;

            _context.Products.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete (int? id)
        {
            if ( id == null)
            {
                return RedirectToAction("Index");
            }

            var product = _context.Products.Where(i => i.ItemId == id).SingleOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    
    }
}
