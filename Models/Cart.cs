using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkateBoard.Models
{
    public class Cart
    {
        //ApplicationDbContext dbContext = new ApplicationDbContext();

        //public Product Product { get; set; }
        //public int qty { get; set; }

        //public double TongTien { get; set; }

        //public Cart(Product product)
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

                });
            }
            else
            {

                item.qty += qty;
            }
        }

        public void UpdateQty(int id, int qty)
        {
            var item = cartItems.Find(s => s.Product.Id == id);
            if (item != null)
            {
                item.qty = qty;
            }
        }

        //tính tổng tiền
        public double TotalMoney()
        {
            var total = cartItems.Sum(s => s.Product.Price * s.qty);
            return (double)total;
        }

        //xóa item khỏi cart
        public void Remove(int id)
        {
            cartItems.RemoveAll(s => s.Product.Id == id);
        }

        //dem so luong san pham trong gio hang
        public int TotalQuantity()
        {
            return cartItems.Sum(s => s.qty);
        }

        //clear gio hang sau khi da thanh toan
        public void ClearCart()
        {
            cartItems.Clear();
        }




    } 
}