using SkateBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkateBoard.ViewModel
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string CurrentCategory { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int currentPage { get; set; }
        public int totalPages { get; set; }
        public int pageSize { get; set; }
    }
}