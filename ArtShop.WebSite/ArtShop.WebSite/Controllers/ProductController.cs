﻿using ArtShop.Data.Model;
using ArtShop.Data.Services;
using ArtShop.WebSite.Services;
using ArtShop.WebSite.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace ArtShop.WebSite.Controllers
{
    //[Authorize]
    public class ProductController : BaseController
    {
        private BaseDataService<Product> MyContext;
        private readonly ArtShopDbContext db = new ArtShopDbContext();

        public ProductController()
        {
            MyContext = new BaseDataService<Product>();
        }

        public ActionResult Index()
        {
            var products = db.Product.Include(p => p.Artist);
            return View(products);
        }

        public ActionResult SelectProduct(int? id)

        {
            if (id == null)

            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = MyContext.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);

        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artist, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("/Content/Products"), filename);
                    file.SaveAs(path);

                    product.Image = filename;
                    this.CheckAuditPattern(product, true);
                    db.Product.Add(product);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
            }

            ViewBag.ArtistId = new SelectList(db.Artist, "Id", "FullName", product.ArtistId);
            ViewBag.MessageDanger = "¡Error al cargar el Producto con su imagén.";
            return View(product);
        }
        //Seleccionar todo en una lista
        public ActionResult ToList()
        {
            var list = MyContext.Get();
            return View(list);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = MyContext.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            this.CheckAuditPattern(product);
            var listModel = MyContext.ValidateModel(product);
            if (ModelIsInvalid(listModel))
                return View(product);
            try
            {
                MyContext.Update(product);
                return RedirectToAction("../Product/ToList");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(product);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = MyContext.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        [HttpPost]
        public ActionResult Delete(Product product)
        {
            try
            {
                MyContext.Delete(product.Id);
                return RedirectToAction("../Product/ToList");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(product);
            }
        }
    }
}