using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ClientServer.Models.Dto
{
    public class KhachHangDto
    {
        public int Ngay { get; set; }
        public int Id { get; set; }
        public String MaKhachHang { get; set; }
        public String TenKhachHang { get; set; }
        public int SoLuongOrder { get; set; }
        public int SoLuongSanPham { get; set; }
        public KhachHangDto() { }
        public KhachHangDto(int a, int b, String c, String d, int e, int f)
        {
            Ngay = a;
            Id = b;
            MaKhachHang = c;
            TenKhachHang = d;
            SoLuongOrder = e;
            SoLuongSanPham = f;

        }
    }
}