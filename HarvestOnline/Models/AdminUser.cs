using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace HarvestOnline.Models
{
    public class AdminUser
    {
        [Key]
        public int AdminId { get; set; }


        [Required(ErrorMessage ="Required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }
    }
}
