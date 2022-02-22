using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MODEL
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Column(TypeName = "nvarchar(270)")]
        public string Name { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Please enter your age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter your collegename")]
        [Column(TypeName = "nvarchar(270)")]
        public string Collegename { get; set; }
        [Required(ErrorMessage = "Please enter your Address")]
        [Column(TypeName = "nvarchar(270)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your Email Address")]
        [Column(TypeName = "nvarchar(270)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password ")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\S{6,20}$", ErrorMessage = "Invalid Password")]
        [Column(TypeName = "nvarchar(270)")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please enter your Role ")]
        [Column(TypeName = "nvarchar(270)")]
        public string Role { get; set; }
        [Required(ErrorMessage = "Please enter your status ")]
        public bool Status { get; set; }
    }
}
