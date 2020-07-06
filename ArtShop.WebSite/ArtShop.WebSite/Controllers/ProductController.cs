using ArtShop.Data.Model;
using ArtShop.Data.Services;
using ArtShop.WebSite.Services;
using OdeToFood.WebSite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.WebSite.Controllers
{
    //[Authorize]
    public class ProductController : BaseController
    {
        private BaseDataService<Product> db;
        // GET: Product


        public ProductController()
        {
            db = new BaseDataService<Product>();
        }

        public ActionResult SelectProduct(int? id)

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
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            this.CheckAuditPattern(product, true);
            var list = db.ValidateModel(product);
            if (ModelIsInvalid(list))
            {
                return View(product);
            }
            try
            {

                db.Create(product);
                return RedirectToAction("../Product/ToList");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(product);
            }
        }
        //Seleccionar todo en una lista
        public ActionResult ToList()
        {
            var list = db.Get();
            return View(list);
        }

        public ActionResult Edit(int? id)
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

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            this.CheckAuditPattern(product);
            var listModel = db.ValidateModel(product);
            if (ModelIsInvalid(listModel))
                return View(product);
            try
            {
                db.Update(product);
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
            var product = db.GetById(id.Value);
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
                db.Delete(product.Id);
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