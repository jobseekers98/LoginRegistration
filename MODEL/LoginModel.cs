using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MODEL
{
     public  class LoginModel
     {


        [Required(ErrorMessage = "Please enter your Email Address")]
        [Column(TypeName = "nvarchar(270)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password ")]
        [Column(TypeName = "nvarchar(270)")]
        public string Password { get; set; }
 
     }
}
