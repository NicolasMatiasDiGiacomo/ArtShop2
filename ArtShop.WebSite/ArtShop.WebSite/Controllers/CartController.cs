using ArtShop.Data.Model;
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
    public class CartController : BaseController
    {
        private readonly BaseDataService<Product> MyContext = new BaseDataService<Product>();
        private readonly ArtShopDbContext db = new ArtShopDbContext();


        // GET: Cart
        public ActionResult Cart()
        {
            var cartItems = db.CartItem.Include(c => c.Cart);
            return View(cartItems);
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

            var cart = db.Cart.FirstOrDefault(c => c.Cookie == cookie);

            if (cart == null)
            {

                cart = new Cart
                {
                    CartDate = DateTime.Now,
                    Cookie = cookie,
                    ItemCount = 1,
                };
                this.CheckAuditPattern(cart, true);

                var cartitem = new CartItem
                {
                    Price = product.Price,
                    ProductId = (int)product.Id,
                    Quantity = (int)cant,
                };
                this.CheckAuditPattern(cartitem, true);

                cart.CartItem = new List<CartItem>() { cartitem };
                db.Cart.Add(cart);
                db.SaveChanges();
            }
            else
            {
                var cartItem = db.CartItem.FirstOrDefault(p => p.ProductId == product.Id);

                if (cartItem == null)
                {
                    var cartitem = new CartItem
                    {
                        Price = product.Price,
                        ProductId = (int)product.Id,
                        Quantity = (int)cant,
                    };
                    this.CheckAuditPattern(cartitem, true);

                    cart.CartItem.Add(cartitem);
                    db.SaveChanges();
                }
                else
                {
                    cartItem.Quantity += (int)cant;
                    this.CheckAuditPattern(cartItem);
                    cart.CartItem.Add(cartItem);
                    db.SaveChanges();
                }
            }


            return RedirectToAction("Cart", "Cart");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var item = db.CartItem.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = db.CartItem.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            db.CartItem.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Cart");
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
}

