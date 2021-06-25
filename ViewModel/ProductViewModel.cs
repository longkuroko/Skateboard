using SkateBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkateBoard.ViewModel
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Product> RelateProduct { get; set; }
        
        public IEnumerable<Category> Categories { get; set; }
    }
}