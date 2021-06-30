using SkateBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkateBoard.ViewModel
{
    public class ShopingCartViewModel
    {
        //public IShopingCartService ShopingCart { get; set; }
        public decimal ShopingCartTotal { get; set; }
        public int ShoppingCartItemsTotal { get; set; }
    }
}