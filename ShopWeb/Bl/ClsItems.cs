using ShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Permissions;

namespace ShopWeb.Bl
{
    public interface Itemservice
    {
        Items GetbyId(int id);
        List<Items> GetAll();
        List<Items> GetSale();
        List<Items> GetMensItems();
        List<Items> GetBags();
        List<Items> GetShoses();
        bool Add(Items item);
        bool Edit(Items item);
        bool Delete(int itemId);


    }

    public class ClsItems : Itemservice
    {

        ShopWebContext ctx;
        public ClsItems(ShopWebContext context)
        {
            ctx = context;
        }
        public List<Items> GetAll()
        {
            List<Items> lstItems = ctx.ItemsTb.Include(a => a.Categories).ToList();
            return lstItems;
        }
        public List<Items> GetSale()
        {
            List<Items> lstsales = ctx.ItemsTb.Where(a => a.Sale == true).ToList();
            return lstsales;
        }
        public Items GetbyId(int id)
        {
            Items item = ctx.ItemsTb.FirstOrDefault(a => a.Id == id);
            return item;

        }
        public List<Items> GetMensItems()
        {
            List<Items> lst = ctx.ItemsTb.Where(a => a.Categories.CategoryName == "Men").ToList();
            return lst;
        }
        public List<Items> GetBags()
        {
            List<Items> lst = ctx.ItemsTb.Where(a => a.Categories.CategoryName == "Bags").ToList();
            return lst;
        }
        public List<Items> GetShoses()
        {
            List<Items> lst = ctx.ItemsTb.Where(a => a.Categories.CategoryName == "Shoses").ToList();
            return lst;
        }
        public bool Add(Items item)
        {
            try
            {
                ctx.Add<Items>(item);
                //ctx.Items.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Items item)
        {
            try
            {
                //Items OldItem = ctx.Items.Where(a => a.ItemId == item.ItemId).FirstOrDefault();
                //OldItem.CategoryId = item.CategoryId;
                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int itemId)
        {
            try
            {
                Items OldItem = ctx.ItemsTb.Where(a => a.Id == itemId).FirstOrDefault();
                ctx.ItemsTb.Remove(OldItem);
                //ctx.Entry(item).State = EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
