using ShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopWeb.Bl
{
    public interface 
        Categoryservice
    {
        List<Categories> GetAll();

    }
  
    public class ClsCategories:Categoryservice
    {
        ShopWebContext ctx;
        public ClsCategories(ShopWebContext context)
        {
            ctx = context;
        }

        public List<Categories> GetAll()
        {
            
           return ctx.CategoriesTb.ToList(); 
        }



    }
}
