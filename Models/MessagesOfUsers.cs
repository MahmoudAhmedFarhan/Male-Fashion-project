using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Models
{
    public class MessagesOfUsers
    {
     
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Eamil { get; set; }
        [MaxLength(500)]
        public String Message { get; set; }
    }
}
