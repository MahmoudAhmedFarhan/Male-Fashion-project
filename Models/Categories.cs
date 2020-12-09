using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Models
{
    public class Categories
    {
       [Key]
        public int CategoryId { get; set; }

        public String CategoryName { get; set; }

       public ICollection<Items> Items { get; set; }
    }
}
