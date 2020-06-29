﻿using ArtShop.Data.Model;
using ArtShop.Data.Services;
using OdeToFood.WebSite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = db.GetById(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            this.CheckAuditPattern(artist, true);
            var list = db.ValidateModel(artist);
            if (ModelIsInvalid(list))
            {
                return View(artist);
            }
            try
            {
                db.Update(artist);
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