using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;



namespace HarvestOnline.Models
{
    public class UserProfile 
    {
        [Key]
        public int UserId { get; set; }
        // Hey it works now XD
        
        public string Password { get; set; }
        public string ReTypePassword { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string ProfileName { get; set; }

        public string Gender { get; set; }
        public string Age { get; set; }
        public string Birthday { get; set; }

    }
}
