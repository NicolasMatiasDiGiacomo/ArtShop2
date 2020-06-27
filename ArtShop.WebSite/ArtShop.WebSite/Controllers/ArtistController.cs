using ArtShop.Data.Model;
using ArtShop.Data.Services;
using OdeToFood.WebSite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.WebSite.Controllers
{
    [Authorize]
    public class ArtistController : BaseController
    {
        BaseDataService<Artist> db;

        public ArtistController()
        {
            db = new BaseDataService<Artist>();
        }
        public ActionResult Index()
        {
            var list = db.Get();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            this.CheckAuditPattern(artist, true);
            var list = db.ValidateModel(artist);
            if (ModelIsInvalid(list))
            {
                return View(artist);
            }
            try
            {
                db.Create(artist);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }
        }
    }
}