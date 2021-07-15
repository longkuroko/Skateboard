using SkateBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkateBoard.ViewModel
{
    public class CheckoutViewModel
    {
        public Order Order { get; set; }
        public Cart Cart { get; set; }
        public double ShopingCartTotal { get; set; }
    }
}