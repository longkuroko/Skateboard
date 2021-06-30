using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkateBoard.Models
{
    public class CartItems
    {
        public Product Product { get; set; }
        public int qty { get; set; }
    }
    public class Cart
    {
     
        //public Cart()
        //{

        //}
        List<CartItems> cartItems = new List<CartItems>();

        public IEnumerable<CartItems> CartItems
        {

            get { return cartItems; }
        }

        public void AddToCart(Product product, int qty = 1)
        {
            var item = cartItems.FirstOrDefault(s => s.Product.Id == product.Id);
            if (item == null)
            {
                cartItems.Add(new CartItems
                {
                    Product = product,
                    qty = qty

                }) ;
            }
            else
            {

                item.qty += qty;
            }
        }


    }
}