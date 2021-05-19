using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Name is Required")]
        public string EventName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        public System.DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string ThemeColor { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Is Full Day field is Required")]
        public bool IsFullDay { get; set; }
        public int? CategoryEventId { get; set; }
        public EventCategory EventCategory { get; set; }
        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}