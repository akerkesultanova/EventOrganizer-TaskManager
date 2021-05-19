using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class EventCategory
    {
        [Key]
        public int CategoryEventId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Category Name of Event is Required")]
        public string CategoryEventName { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}