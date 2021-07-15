using SkateBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkateBoard.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        //dang nhap
        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            var login = db.Customers.Where(s => s.Username == customer.Username && s.Password == customer.Password).FirstOrDefault();

            if(login == null)
            {
                ViewBag.error = "Login failed";
                return View("Login", "Customer");

            }
            else
            {
                Session["Customer"] = login;
                ViewBag.Thongbao = "Đăng nhập thành công";
                return RedirectToAction("Index", "Home");
            }
        }

        //ho so
        public ActionResult ProfileName()
        {
            if (Session["UserLogin"] != null)
            {
                ViewBag.Profile = ((Customer)Session["UserLogin"]).Username;
                return PartialView();
            }
            ViewBag.Profile = "Đăng nhập/ Đăng ký";
            return PartialView();
        }
        //dang xuat
        public ActionResult LogOut()
        {
            Session["Customer"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }
        //dang ky
        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var check = db.Customers.FirstOrDefault(s => s.Username == customer.Username);
                if(check == null)
                {
                    Customer customer1 = new Customer()
                    {
                        fullname = customer.fullname,
                        Username = customer.Username,
                        Password = customer.Password,
                        Email = customer.Email,
                        Address = customer.Address,
                        Phone = customer.Phone
                        
                    };


                    db.Customers.Add(customer1);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Customer");
                }
            }
            else
            {
                ViewBag.error = "Tên đăng nhập đã tồn tại!";
                return View();
            }

            return View();
                         
        }

        //[HttpPost]
        //public JsonResult ShowInfo(int id)
        //{
        //    var customer = db.Customers.Where(x => x.Id == id).FirstOrDefault();
        //    if (customer != null)
        //    {
        //        return Json(new
        //        {
        //            FullName = customer.fullname,                    
        //            Username = customer.Username,
        //            Address = customer.Address,
        //            Phone = customer.Phone,
        //            Email = customer.Email
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("CannotFindCustomer", JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpPost]
        //public JsonResult UpdateInfo(int id, string fullName, string username, string address, string phone, string email)
        //{

        //    var customer = db.Customers.Where(x => x.Id == id).FirstOrDefault();
        //    customer.fullname = fullName;
            
        //    customer.Username = username;
        //    customer.Address = address;
        //    customer.Phone = phone;
        //    customer.Email = email;

        //    UpdateModel(customer);
        //    db.SaveChanges();

        //    Session["UserLogin"] = customer;

        //    return Json("Success", JsonRequestBehavior.AllowGet);
        //}


        //[HttpPost]
        //public JsonResult ChangePwd(int id, string newPwd)
        //{
        //    var customer = db.Customers.Where(x => x.Id == id).FirstOrDefault();
        //    if (customer != null)
        //    {
        //        customer.Password = newPwd;
        //        UpdateModel(customer);
        //        db.SaveChanges();
        //        Session["UserLogin"] = customer;
        //        return Json("Success", JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("CannotFindCustomer", JsonRequestBehavior.AllowGet);
        //    }
        //}
    }

}
