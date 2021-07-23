using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkateBoard.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [Display(Name ="Mã sản phẩm")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Display(Name = "Số lượng")]
        public int Qty { get; set; }
        [Display(Name = "Đơn giá")]
        public decimal Price { get; set; }

        [Display(Name = "Mã đơn hàng")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        
    }
}