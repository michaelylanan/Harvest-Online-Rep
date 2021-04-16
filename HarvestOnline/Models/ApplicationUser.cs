using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
namespace HarvestOnline.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        //Foreign Key of Id in AspNetUsers
        public virtual ApplicationUser ApplicationUser { get; set; }
    

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Required*")]
        public string FullName { get; set; }


        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Required*")]
        [StringLength(11, ErrorMessage = "Phone number must be 11 Digits!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[.]?([0-9]{4})[. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid. Must be 11 digits and numeric")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Profile Name")]
        [Required(ErrorMessage = "Required*")]
        public string ProfileName { get; set; }

        [Required(ErrorMessage = "Required*")]
        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Required*")]
        public string Birthday { get; set; }

        [Required(ErrorMessage = "Required*")]
        [Range(0, 120, ErrorMessage = "{0} age must be between 0 -120")]
        public int Age { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        //Foreign Key of CustomerId
        public virtual Customer Customer { get; set; }
        //-----------------------------------------

        [Display(Name = "ZIP/Postal Code")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "ZIP Code must be 3 -4 characters long!")]
        [Required(ErrorMessage = "Required*")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Required*")]
        public Region Region { get; set; }

        [Required(ErrorMessage = "Required*")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Required*")]
        public string City { get; set; }

        [Required(ErrorMessage = "Required*")]
        public string Barangay { get; set; }
       
        [Display(Name = "Building No./ House No./ Street")]
        [Required(ErrorMessage = "Required")]
        public string BuildingNo { get; set; }

    }

    public enum Region
    {
        NationalCapitalRegion = 1,
        CentralLuzon = 2,
        CALABARZON = 3,
    }
}
   
