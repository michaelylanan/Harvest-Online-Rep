using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HarvestOnline.Models
{
    public class CheckOutUser
    {
        [Key]
        public int OrderId { get; set; }
        public virtual Customer Customer { get; set; }        
        public virtual AddToCart AddToCart { get; set; }
        public string ProductName { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ShippingFee { get; set; }

        public decimal TotalPayment { get; set; }

        public DateTime? DateAdded { get; set; }
        public string Status { get; set; }

    }
}
