using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ClientServer.Models.Dto
{
    public class ChiTietThongTin
    {
        public decimal TongTienPhaiTra { get; set; }
        public decimal TienGiamHoaDon { get; set; }
        public String MaSanPham { get; set; }
        public String TenSanPham { get; set; }
        public decimal Gia { get; set; }
        public decimal TienGiamGia { get; set; }
        public decimal ThanhTienSauGiamGia { get; set; }
        public int SoLuong { get; set; }
        public String TenThuongHieu { get; set; }
        public String TenLoaiSanPham { get; set; }

        public ChiTietThongTin()
        {

        }
        public ChiTietThongTin(decimal a, decimal b, String c, String d, decimal e, decimal f, decimal g, int h, String i, String k)
        {
            TongTienPhaiTra = a;
            TienGiamHoaDon = b;
            MaSanPham = c;
            TenSanPham = d;
            Gia = e;
            TienGiamGia = f;
            ThanhTienSauGiamGia = g;
            SoLuong = h;
            TenThuongHieu = i;
            TenLoaiSanPham = k;
        }

    }
}