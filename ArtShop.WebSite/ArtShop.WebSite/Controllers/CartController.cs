﻿using ArtShop.Data.Model;
using ArtShop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.WebSite.Controllers
{
    public class CartController : Controller
    {
        BaseDataService<Product> db;

        public CartController()
        {
            db = new BaseDataService<Product>();
        }

        // GET: Cart
        public ActionResult Cart()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var product = db.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        /*[HttpPost, ActionName("Delete")] 
        public ActionResult DeleteConfirmed(int? id)
        {
            var product = db.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            db.Delete(product);
            db.SaveChanges();
            return RedirectToAction("Index");*/
        }
       /* protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/





    }

