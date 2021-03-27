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


namespace HarvestOnline.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;            
        public ProductController(ApplicationDbContext context)
        {
            _context = context;        
        }

        public IActionResult Index(String searchby, String search)
        {
            var list = _context.Products.ToList();
            //Code block for search
            ApplicationUser user = new();
            if (searchby == "ItemName" && search != null)
            {
                return View(list.Where(x => x.ItemName.Contains(search)).ToList());
            }
            else if(searchby == "Supplier" && search != null)
            {
                return View(list.Where(x => x.Supplier.Contains(search)).ToList());
            }
            else
            {
                return View(list);
            }
        }

        public IActionResult DisplayView(String searchby, String search)
        {
            ApplicationUser user = new();
            var list = _context.Products.ToList();
            if(searchby =="ItemName" && search != null)
            {   
                return View(list.Where(x => x.ItemName.Contains(search)).ToList());
            }
            else
            {
                return View(list);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product record, IFormFile ImagePath)
        {
            var product = new Product();

            product.ItemName = record.ItemName;
            product.Supplier = record.Supplier;
            product.ItemSellingQuanity = record.ItemSellingQuanity;
            product.ItemUnit = record.ItemUnit;
            product.Price = record.Price;
            product.ItemPortionPrice = record.ItemPortionPrice;
            product.DateAdded = DateTime.Now;


            if(ImagePath!=null)
            {
                if(ImagePath.Length>0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/products", ImagePath.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ImagePath.CopyTo(stream);
                    }
                    product.ImagePath = "~/img/products/"+ ImagePath.FileName;
                }
            }

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
