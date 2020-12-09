using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ShopWeb.Models
{
    public class Items
    {
        public int Id { get; set; }

        [Required(ErrorMessage =" Please Enter Name")]
        public string Name{ get; set; }

        [MaxLength(200)]
        public string ImageName { get; set; }

        [Required(ErrorMessage = " Please Enter SalesPrice")]
        public decimal SalesPrice { get; set; }

        [Required(ErrorMessage = " Please Enter SalePurchasePrice")]
        public decimal SalePurchasePrice{ get; set; }

        public Boolean Sale { get; set; }

        public int CategoryId { get; set; }

        public Categories Categories { get; set; }
    }
}
