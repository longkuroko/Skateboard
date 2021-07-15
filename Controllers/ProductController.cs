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
        public ActionResult Index(string Search,int? page)
        {
            ViewBag.Keyword = Search;
            var products = db.Products.Include(p => p.Category).ToList();
            if (!String.IsNullOrEmpty(Search))
            {
                ViewBag.Search = Search;
                products = products.Where(p => p.Name.Contains(Search)).ToList();
            }

            return View(products.ToPagedList(page ?? 1, 9));
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
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

        public ActionResult RelatedProduct (int id)
        {
           var product = db.Products.Include(s => s.Category).FirstOrDefault(p => p.Id == id);

            ProductViewModel productView = new ProductViewModel
            {

                Product = product,
                RelateProducts = db.Products
                .Where(f => f.CategoryId == product.CategoryId)
                .Take(3)
                .OrderBy(s => s.Name),
                Categories = db.Categories.Take(15).OrderBy(s => s.Name)
            };
            return View(productView);
        }

    }
}
