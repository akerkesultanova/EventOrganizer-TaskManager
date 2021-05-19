using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class ToDo
    {
        [Key]
        public int TaskId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        public bool IsDone{ get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}