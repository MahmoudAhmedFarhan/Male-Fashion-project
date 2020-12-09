using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Models
{
    public class HomePageModel
    {
        public  IEnumerable<TbSlider> lstSliderImages { get; set; }
        public IEnumerable<Items> lstAlltems { get; set; }
        public IEnumerable<Items> lstNewItems { get; set; }
        public IEnumerable<Items> lstBestSeller { get; set; }
        public IEnumerable<Items> lstsale { get; set; }
    }
}
