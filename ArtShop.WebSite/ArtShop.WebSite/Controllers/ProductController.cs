using ArtShop.Data.Model;
using ArtShop.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArtShop.WebSite.Controllers
{
    public class ProductController : Controller
    {
        private BaseDataService<Product> db;
        // GET: Product

        
        public ProductController()
        {
            db = new BaseDataService<Product>();
        }

    public ActionResult SelectProduct(int? id)

      {
        if(id == null)

          {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
            var product = db.GetById(id.Value);
            if(product==null)
            {
              return HttpNotFound();
            }
           return View(product);

       }

        //seleccionar todo
       // public ActionResult SelectProduct()
        //{
          //  var list = db.Get();
            //return View(list);
        //}
    }
}