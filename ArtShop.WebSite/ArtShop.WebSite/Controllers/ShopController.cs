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
        private readonly BaseDataService<Product> db = new BaseDataService<Product>();

        public ActionResult Index()
        {
            var products = db.Get(null, null, "Artist");
            return View(products);
        }
    }
}