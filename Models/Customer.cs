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
        [Display(Name ="Tài khoản")]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string fullname { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        public string Email { get; set; }
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }

         public ICollection<Order> Orders { get; set; }
    }
}