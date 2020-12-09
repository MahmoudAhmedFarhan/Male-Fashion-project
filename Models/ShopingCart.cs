using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Models
{
    public class ShopingCart
    {
        public ShopingCart()
        {
            shopingCartItems = new List<ShopingCartItem>();
        }
        public ICollection<ShopingCartItem> shopingCartItems { get; set; }
        public decimal Total { get; set; }
    }
}
