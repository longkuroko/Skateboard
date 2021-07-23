using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkateBoard.Models
{
    public class Admin
    {
        public int ID { get; set; }
        [Display(Name ="Tên đăng nhập")]
        public string username { get; set; }

        [Display(Name = "Mật khẩu")]
        public string password { get; set; }
    }
}