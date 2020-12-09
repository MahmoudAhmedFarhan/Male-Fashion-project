using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Bl;
using ShopWeb.Models;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;
using ShopWeb.Bl;

namespace ShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemsController : Controller
    {

        Itemservice oItemservice;
        Categoryservice oCategoryservice;
        public ItemsController( Itemservice Items, Categoryservice categories)
        {
            oItemservice = Items;
            oCategoryservice = categories;
        }
        public IActionResult List()
        {
            return View(oItemservice.GetAll());
        }

        public IActionResult Edit(int? id)
        {
           
            ViewBag.Categories = oCategoryservice.GetAll();
            if (id != null)
            {
                return View(oItemservice.GetbyId(Convert.ToInt32(id)));
            }
            else
                return View();
        }

        public IActionResult Delete(int item)
        {

            oItemservice.Delete(item);
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Save(Items item, List<IFormFile> files )
        {
            foreach (var file in files)
            {
                if(file.Length>0)
                {
                    string ImageName = Guid.NewGuid().ToString();
                    var filesPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Uploads", ImageName + ".jpg");
                    using (var stream = System.IO.File.Create(filesPath))
                    {
                        await file.CopyToAsync(stream);
                    }
                    item.ImageName = ImageName + ".jpg";
                }
            }
         
            if (item.Id == 0)
                oItemservice.Add(item);
            else
                oItemservice.Edit(item);
            return RedirectToAction("List");
        }
   //item.ImageName = string.Empty;
          
        }
    }
