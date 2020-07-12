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
    public class CartController : BaseController
    {
        private readonly BaseDataService<Product> MyContext = new BaseDataService<Product>();
        private readonly ArtShopDbContext db = new ArtShopDbContext();


        // GET: Cart
        public ActionResult Cart()
        {
            var products = MyContext.Get(null, null, "Artist");
            return View(products);
        }

        [HttpGet]
        public ActionResult Create(int? id, int? cant)
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
            var cookie = "ArtShop-cookie";

            var cart = new Cart
            {
                CartDate = DateTime.Now,
                Cookie = cookie,
                ItemCount = 1,
            };
            this.CheckAuditPattern(cart, true);

            var cartitem = new CartItem
            {
                Price = (float)product.Price,
                ProductId = (int)product.Id,
                Quantity = (int)cant,
            };
            this.CheckAuditPattern(cartitem, true);

            cart.CartItem = new List<CartItem>() { cartitem };
            db.Cart.Add(cart);
            db.SaveChanges();

            return RedirectToAction("Cart", "Cart");
        }
    }
}
