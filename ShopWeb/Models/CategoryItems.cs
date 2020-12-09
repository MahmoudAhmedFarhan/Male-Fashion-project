using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Models
{
    public interface ICategoryItemsService
    {
        ICollection<Categories> List_Categories { get; set; }
        ICollection<Items> List_Items { get; set; }
        List<Categories> getCategories();
        List<Items> getItems();
    }
    public class CategoryItems: ICategoryItemsService
    {

      
        ShopWebContext db;
        public CategoryItems (ShopWebContext context)
        {
            db = context;
        }
        public ICollection<Categories> List_Categories { get; set; }
        public ICollection <Items> List_Items { get; set; }


        public List<Categories> getCategories()
        {
            return db.CategoriesTb.ToList();

        }
        public List<Items> getItems()
        {
            return db.ItemsTb.ToList();

        }
    }
}
