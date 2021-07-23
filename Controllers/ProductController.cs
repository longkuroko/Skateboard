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
            var products = db.Products.Include(p => p.Category).ToList();
            if (!String.IsNullOrEmpty(Search))
            {
                ViewBag.Search = Search;
                products = products.Where(p => p.Name.ToLower().Contains(Search.ToLower())).ToList();
            }

            return View(products.ToPagedList(page ?? 1, 9));
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
            ViewBag.RelatedProducts = new List<Product>(RelatedProducts(productid));
            //var relatedProduct = new List<Product>(RelatedProducts(productid));

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public ActionResult RelatedProduct(int id)
        //{
        //    var product = db.Products.Include(s => s.Category).FirstOrDefault(p => p.Id == id);

        //    ProductViewModel productView = new ProductViewModel
        //    {

        //        Product = product,
        //        RelateProducts = db.Products
        //        .Where(f => f.CategoryId == product.CategoryId)
        //        .Take(3)
        //        .OrderBy(s => s.Name),
        //        Categories = db.Categories.Take(15).OrderBy(s => s.Name)
        //    };
        //    return View(productView);
        //}

        public List<Product> RelatedProducts(int id)
        {
            var product = db.Products.Find(id);
            return db.Products.Where(x => x.Id != id && x.CategoryId == product.CategoryId).Take(4).ToList();
        }

        public ActionResult Category()
        {
             var category = from cd in db.Categories select cd;

            return PartialView(category);
        }
        public ActionResult ProductByCategory(int id, int? page)
        {
            var products = db.Products.Where(s => s.CategoryId == id).ToList();
            return View(products.ToPagedList(page ?? 1,9));
        }
       

    }
}
