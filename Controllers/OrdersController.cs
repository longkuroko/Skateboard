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
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index(int id)
        {
            var orders = db.Orders.Include(o => o.Customer)
                .Where(p => p.CustomerId == id);
            return View(orders.ToList());
        }

        //chi tiết đơn hàng
        //public ActionResult ChiTietDonHang()
        //{

        //}



        public ActionResult Details(int id)
        {
            var orderDetails = db.OrderDetails.Include(o => o.Order).Include(o => o.Product).Where(p=>p.OrderId == id).OrderByDescending(x=>x.Order.OrderDay);
            return View(orderDetails.ToList());
        }
    }


}
