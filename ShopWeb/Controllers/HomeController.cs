using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopWeb.Bl;
using ShopWeb.Models;


namespace ShopWeb.Controllers
{
    // authorized users only can interact with action in (homecontroller)can but [Authorize] in controller and actions also
    public class HomeController : Controller
    {

        
        Categoryservice oCategoryservice;
        Itemservice oItemservice;
        Slidersservice oSlidersservice;
        public HomeController(Categoryservice Category, Itemservice Items, Slidersservice Sliders)
        {
            oCategoryservice = Category;
            oItemservice = Items;
            oSlidersservice = Sliders;
        }


        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstsale = oItemservice.GetSale();
            model.lstNewItems = oItemservice.GetAll().Take(5);
            //model.lstBestSeller = model.lstAlltems.Take(3);
            model.lstSliderImages = oSlidersservice.GetAll();
            return View(model);
        }
        [Authorize]
        public IActionResult Shop()
        {
            ShopPageModel model = new ShopPageModel();
            model.LstBags = oItemservice.GetMensItems();
            model.List_Categories = oCategoryservice.GetAll();
            model.List_Items = oItemservice.GetAll();
            model.LstMens = oItemservice.GetMensItems();
            model.LstBags = oItemservice.GetBags();
            model.LstShoses = oItemservice.GetShoses();
           //var x= model.List_Items.Sum();
            return View(model);
        }
        
        public IActionResult AddToCart(int id)
        {
            ShopingCart shopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            if (shopingCart == null)
                shopingCart = new ShopingCart();

            Items Item = oItemservice.GetbyId(id);

            ShopingCartItem shopingItem = shopingCart.shopingCartItems.Where(a => a.ItemId == id).FirstOrDefault();
            if (shopingItem != null)// check if  this item in cart or not
            {
                shopingItem.Qty++;
                shopingItem.Total = shopingItem.Price * shopingItem.Qty;
            }
            else
            {
                shopingCart.shopingCartItems.Add(new ShopingCartItem
                {
                    ItemId = Item.Id,
                    ItemName = Item.Name,
                    Price = Item.SalesPrice,
                    ImageName=Item.ImageName,
                    Qty = 1,
                    Total = Item.SalesPrice
                });
            }
            shopingCart.Total = shopingCart.shopingCartItems.Sum(a => a.Total);

            HttpContext.Session.SetObjectAsJson("Cart", shopingCart);
            return Redirect("/Home/Shop");
        }

        public IActionResult RemoveItem(int id)
        {

            ShopingCart shopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            shopingCart.shopingCartItems.Remove(shopingCart.shopingCartItems.Where(a => a.ItemId ==id).FirstOrDefault());
            shopingCart.Total = shopingCart.Total - shopingCart.shopingCartItems.Sum(a => a.Total);
            HttpContext.Session.SetObjectAsJson("Cart", shopingCart);

            return RedirectToAction("ShopingCart");
        }

        public IActionResult ShopingCart()
        {
           ShopingCart shopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");

            return View(shopingCart);
        }

        public IActionResult CheckOut()
        {
            ShopingCart shopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            return View(shopingCart);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
