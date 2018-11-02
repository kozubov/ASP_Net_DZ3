using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASP_3.Models
{
    public class ModelUser
    {
        [Required(ErrorMessage = "Required field")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Must be between 3 and 25 characters")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Required field")]
        [StringLength(33, MinimumLength = 7, ErrorMessage = "Must be between 7 and 33 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required field")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect mail template")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Phone { get; set; }

        public string role { get; set; }
    }
}