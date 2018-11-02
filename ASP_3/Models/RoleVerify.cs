using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASP_3.Models
{
    public class ModelRole
    {
        [Required(ErrorMessage = "Required field")]
        public string Name { get; set; }
    }
}