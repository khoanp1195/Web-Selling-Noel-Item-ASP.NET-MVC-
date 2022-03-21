using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class RegisterModels
    {
        [Required]
        public string Username { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [MinLength(6,ErrorMessage ="Chieu dai toi thieu")]
        [Required]
        public string Pass { get; set; }
        [Required]
        [Compare("Pass",ErrorMessage ="Mat khau khong hop le")]
        public string CfPass { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        public string PhoneNumber { get; set; }


    }
    public class LoginModels
    {
        public string Email { get; set; }

        public string Pass{ get; set; }
    }
}