using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkateBoard.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        public string fullname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

         public ICollection<Order> Orders { get; set; }
    }
}