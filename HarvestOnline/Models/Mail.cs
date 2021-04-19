using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;


namespace HarvestOnline.Models
{
    public class Mail
    {
        [Key]
        public int UserId { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Format!")]
        [Required(ErrorMessage = "Required.")]
        public String Email { get; set; }
    }
}
