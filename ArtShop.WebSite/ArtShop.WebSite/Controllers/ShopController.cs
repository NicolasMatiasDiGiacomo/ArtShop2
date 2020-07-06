using ArtShop.Data.Model;
using ArtShop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.WebSite.Controllers
{
    public class ShopController : Controller
    {
        private BaseDataService<Product> db;
        // GET: Product


        public ShopController()
        {
            db = new BaseDataService<Product>();
        }

       
        public ActionResult Index()
        {
            var list = db.Get();
            return View(list);
        }
    }
}