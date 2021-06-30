using SkateBoard.Models;
using SkateBoard.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SkateBoard.Controllers
{
    public class ShopingCartController : Controller
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();
        //private readonly Cart _cart;

        //public ShopingCartController(ApplicationDbContext dbContext , Cart cart)
        //{
        //    _dbContext = dbContext;
        //    _cart = cart;
        //}

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        //them san pham vao gio hang
        public ActionResult AddToCart(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(s => s.Id == id);
            if(product != null)
            {
                GetCart().AddToCart(product);
            }
            return RedirectToAction("ShowtoCart", "ShopingCart");
        }
        //xem gio hang
        public ActionResult ShowtoCart()
        {
            if(Session["Cart"] == null)
            {
                return RedirectToAction("ShowtoCart", "ShopingCart");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

    }
}