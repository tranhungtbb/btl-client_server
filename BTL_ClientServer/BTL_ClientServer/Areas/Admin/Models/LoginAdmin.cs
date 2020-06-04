using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTL_ClientServer.Areas.Admin.Models
{
    public class LoginAdmin
    {
        [Required(ErrorMessage = "Mời nhập user name")]
        public string TenDangNhap { set; get; }

        [Required(ErrorMessage = "Mời nhập password")]
        public string MatKhau { set; get; }

        public bool RememberMe { set; get; }
    }
}