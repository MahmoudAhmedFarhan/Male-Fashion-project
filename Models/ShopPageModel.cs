using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Models
{
    public class ShopPageModel
    {
        public IEnumerable<Categories> List_Categories { get; set; }
        public IEnumerable<Items> List_Items { get; set; }
        public IEnumerable<Items> LstMens { get; set; }
        public IEnumerable<Items> LstBags { get; set; }
        public IEnumerable<Items> LstShoses { get; set; }

    }
}
