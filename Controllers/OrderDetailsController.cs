using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkateBoard.Models;

namespace SkateBoard.Controllers
{
    public class OrderDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderDetails
        public ActionResult Index(int id)
        {
            var orderDetails = db.OrderDetails.Include(o => o.Order).Include(o => o.Product).Where(x=>x.OrderId == id);
            return View(orderDetails.ToList());
        }

    }
}
