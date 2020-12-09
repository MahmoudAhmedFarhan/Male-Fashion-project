using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ShopWeb.Models
{
    public class Users
    {
        public int  Id { get; set; }

        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
         [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$",ErrorMessage="Invaild Eamil Format")]
        public string Eamil { get; set; }

        public decimal PhoneNumber { get; set; }

        public string  ReturnUrl { get; set; }

    }
}
