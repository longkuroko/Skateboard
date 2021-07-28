using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SkateBoard.Models;

namespace SkateBoard.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        // GET: Admin/Products
        //public ActionResult Index(string Search, int? page)
        //{
        //    var products = db.Products.Include(p => p.Category).OrderByDescending(x=>x.Id);
        //    if (!String.IsNullOrEmpty(Search))
        //    {
        //        ViewBag.Search = Search;
        //        products = products.Where(p => p.Name.ToLower().Contains(Search.ToLower())).ToList();
        //    }

        //    return View(products.ToPagedList(page ?? 1, 6));
        //}
        public ActionResult Index(string Search, int? page)
        {
            var products = db.Products.Include(p => p.Category).OrderByDescending(x => x.Id).ToList();
            if (!String.IsNullOrEmpty(Search))
            {
                ViewBag.Search = Search;
                products = products.Where(p => p.Name.ToLower().Contains(Search.ToLower()) || p.Category.Name.ToLower().Contains(Search.ToLower())).ToList();
            }

            return View(products.ToPagedList(page ?? 1, 6));
        }

        // GET: Admin/Products/Details/5
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

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
           
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Price,Image,Details,CategoryId")] Product product, HttpPostedFileBase file)
        //{
        //    if (ModelState.IsValid)
        //    {

        //            if(file == null)
        //            {
        //                ViewBag.Thongbao = "Vui lòng chọn ảnh cho sản phẩm";
        //                return View();
        //            }
        //            else
        //            {
        //                var filename = Path.GetFileName(file.FileName);
        //                var path = Path.Combine(Server.MapPath("~/UploadFile"), filename);
        //                if (System.IO.File.Exists(path))
        //                {
        //                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
        //                }
        //                else
        //                {
        //                    file.SaveAs(path);
        //                }
        //                product.Image = filename;
        //                db.Products.Add(product);
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //    }
        //    var list = db.Categories.ToList();
        //    ViewBag.CategoryId = new SelectList(list, "Id", "Name");
        //    return View(product);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Image,Details,CategoryId,SLton")] Product product, HttpPostedFileBase fileupload)
        {

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            if(fileupload != null)
            {
                string filename = Path.GetFileName(fileupload.FileName);
                string path = Server.MapPath("~/img/" + filename);
                fileupload.SaveAs(path);
                product.Image = "img/" + filename;

            }  
            if (ModelState.IsValid)
            {
    
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
 
            return View(product);
        }
        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Image,Details,CategoryId,SLton")] Product product, HttpPostedFileBase fileupload)
        {
            if (fileupload != null)
            {
                string filename = Path.GetFileName(fileupload.FileName);
                string path = Server.MapPath("~/UploadFile/" + filename);
                fileupload.SaveAs(path);
                product.Image = "UploadFile/" + filename;

            }
            if (ModelState.IsValid)
            {
            
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
