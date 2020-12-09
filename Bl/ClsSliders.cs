using Microsoft.EntityFrameworkCore;
using ShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Bl
{
    public interface Slidersservice
    {
        
        List<TbSlider> GetAll();
        TbSlider GetbyId(int id);
        bool Add(TbSlider slider);
        bool Edit(TbSlider slider);
        bool Delete(int Id);

    }

    public class ClsSliders : Slidersservice
    {
        ShopWebContext ctx;
        public ClsSliders(ShopWebContext context)
        {
            ctx = context;
        }
        public List<TbSlider> GetAll()
        {
            List<TbSlider> lstSliders = ctx.TbSlider.ToList();
            return lstSliders;
        }
     
        public TbSlider GetbyId(int id)
        {
            TbSlider slider = ctx.TbSlider.FirstOrDefault(a => a.sliderId == id);
            return slider;

        }
        public bool Add(TbSlider slider)
        {
            try
            {
                ctx.Add<TbSlider>(slider);
                //ctx.Items.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(TbSlider Slider)
        {
            try
            {
                //Items OldItem = ctx.Items.Where(a => a.ItemId == item.ItemId).FirstOrDefault();
                //OldItem.CategoryId = item.CategoryId;
                ctx.Entry(Slider).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                TbSlider OldSlider = ctx.TbSlider.Where(a => a.sliderId ==Id).FirstOrDefault();
                ctx.TbSlider.Remove(OldSlider);
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
