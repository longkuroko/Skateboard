using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SkateBoard.Models;
using SkateBoard.ViewModel;

namespace SkateBoard.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index(string Search, int? page)
        {
            var products = db.Products.Include(p => p.Category).OrderByDescending(x=>x.Id).ToList();
            if (!String.IsNullOrEmpty(Search))
            {
                ViewBag.Search = Search;
                products = products.Where(p => p.Name.ToLower().Contains(Search.ToLower())).ToList();
            }

            return View(products.ToPagedList(page ?? 1, 6));
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            int productid = id ?? default(int);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);

            var relatedProduct = db.Products.Where(x=>x.CategoryId == product.CategoryId).Take(4).ToList();
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductViewModel viewModel = new ProductViewModel
            {
                Product = product,
                RelateProducts = relatedProduct
            };
            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Category()
        {
             var category = from cd in db.Categories select cd;

            return PartialView(category);
        }
        public ActionResult ProductByCategory(int id, int? page)
        {
            var products = db.Products.Where(s => s.CategoryId == id).OrderByDescending(x=>x.Id).ToList();
            return View(products.ToPagedList(page ?? 1,6));
        }
       

    }
}
