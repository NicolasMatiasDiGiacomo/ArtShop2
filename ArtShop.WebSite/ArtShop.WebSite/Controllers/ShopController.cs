using ArtShop.Data.Services;
using ArtShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.WebSite.Controllers
{
    public class ShopController : Controller
    {
        BaseDataService<Artist> db;

        public ShopController()
        {
            db = new BaseDataService<Artist>();
        }

        public ActionResult Index()
        {
            var list = db.Get();
            return View(list);
        }
    }
}