using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkateBoard.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime OrderPlaceTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        [Required]
        public string Email { get; set; }

        public decimal OrderTotal { get; set; }

        [Required]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {


        }
    }
}