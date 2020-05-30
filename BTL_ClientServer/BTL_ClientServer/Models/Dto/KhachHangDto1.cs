using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ClientServer.Models.Dto
{
    public class KhachHangDto1
    {
        public int Id { set; get; }
        public String MaKhachHang { get; set; }
        public String TenKhachHang { get; set; }
        public String DiaChi { get; set; }
        public String Email { get; set; }
        public Boolean GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public int SoLuong { get; set; }
        public decimal TongTienDaTra { get; set; }

        public KhachHangDto1()
        {
        }

        public KhachHangDto1(int id, string maKhachHang, string tenKhachHang, string diaChi, string email, bool gioiTinh, DateTime ngaySinh, int soLuong, decimal tongTienDaTra)
        {
            Id = id;
            MaKhachHang = maKhachHang;
            TenKhachHang = tenKhachHang;
            DiaChi = diaChi;
            Email = email;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            SoLuong = soLuong;
            TongTienDaTra = tongTienDaTra;
        }
    }
}