using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkateBoard.Models
{
    public class ShopingCartItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Qty { get; set; }

        [Required]
        [StringLength(255)]
        public string ShoppingCartId { get; set; }
    }
}