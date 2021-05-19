using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Organization Name is Required")]
        public string OrganizationName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Info is Required")]
        public string Info { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Organizer Name is Required")]
        public string Organizer { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}