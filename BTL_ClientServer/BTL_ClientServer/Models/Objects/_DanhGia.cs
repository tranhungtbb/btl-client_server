using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ClientServer.Models.Objects
{
    public class _DanhGia
    {
        public int Id { get; set; }

        public int? IdSanPham { get; set; }

        public int? IdKhachHang { get; set; }

        public int? IdDanhGia { get; set; }

        public string TenKhachHang { get; set; }

        public string Comment { get; set; }
        
        public string Ngay { get; set; }
    }
}