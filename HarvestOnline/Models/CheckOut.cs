using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace HarvestOnline.Models
{
    public class CheckOut
    {
        [Key]
        public int OrderId { get; set; }

        public int NumberOfItem { get; set; }

        public int Qty { get; set; }

        public string ItemName{ get; set; }

        public string Price { get; set; }

        public float ShippingFee { get; set; }

        public decimal TotalPayment { get; set; }

        public string Total { get; set; }

        


    }
}
