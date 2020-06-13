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
        private IArtistData db;

        public ShopController()
        {
            db = new InMemoryArtistData();
        }

        public ActionResult Index()
        {
            var list = db.GetAll();
            return View(list);
        }
    }
}