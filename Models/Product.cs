
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
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Details { get; set; }

        public Category Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Brand Brand { get; set; }
        [Required]
        public int BrandId { get; set; }
    }
}