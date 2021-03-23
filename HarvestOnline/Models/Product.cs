using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace HarvestOnline.Models
{

    public class Product
    {
        [Key]
        public int ItemId { get; set; }

        [Display(Name = "Item Name")]
        [Required(ErrorMessage ="Required")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Supplier { get; set; }

        [Display(Name = "Selling Quantity")]
        [Range(0.00, 1000.00, ErrorMessage ="Invalid Selling Quantity Range")]
        public double ItemSellingQuanity { get; set; }

        [Display(Name ="Item Unit")]
        public string ItemUnit {get;set;}

        [Range(0.00, 1000000.00, ErrorMessage = "Invalid Price Range")]
        public decimal Price { get; set; }

        [Display(Name = "Portion price")]
        [Range(0.00, 1000000.00, ErrorMessage = "Invalid Price Range")]
        public decimal ItemPortionPrice { get; set; }

        [Display(Name = "Image")]
        public  string ImagePath { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }
        public string Status { get; set; }

    }
}
