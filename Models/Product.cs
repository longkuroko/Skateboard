
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkateBoard.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Gía")]
        public decimal Price { get; set; }
        [Display(Name = "Ảnh sản phẩm")]
        public string Image { get; set; }
        [Display(Name = "Chi tiết sản phẩm")]
        public string Details { get; set; }
        [Display(Name = "Danh mục")]
        public Category Category { get; set; }
        [Required]
        public int CategoryId { get; set; }      
     
        public Product()
        {

        }
    }
}