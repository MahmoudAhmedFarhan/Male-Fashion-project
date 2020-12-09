using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Bl;
using ShopWeb.Models;

namespace ShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        Slidersservice oSlidersservice;
        public SlidersController(Slidersservice Sliders)
        {

            oSlidersservice = Sliders;
        }
        
        
        public IActionResult List()
        {
            return View(oSlidersservice.GetAll());
        }

        public IActionResult Edit(int? id)
        {

            //ViewBag.Categories = oSlidersservice.GetAll();
            if (id != null)
            {
                return View(oSlidersservice.GetbyId(Convert.ToInt32(id)));
            }
            else
                return View();
        }

        public IActionResult Delete(int item)
        {

            oSlidersservice.Delete(item);
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Save(TbSlider slider, List<IFormFile> files)
        {
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString();
                    var filesPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Uploads", ImageName + ".jpg");
                    using (var stream = System.IO.File.Create(filesPath))
                    {
                        await file.CopyToAsync(stream);
                    }
                    slider.ImageName = ImageName+".jpg";
                }
            }

            if (slider.sliderId == 0)
                oSlidersservice.Add(slider);
            else
                oSlidersservice.Edit(slider);
            return RedirectToAction("List");
        }
    }
}
