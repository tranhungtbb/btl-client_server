using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ClientServer.Models.Dto
{
    public class SanPhamDto
    {
        public int IdSanPham { get; set; }
        public String TenSanPham { get; set; }
        public decimal Gia { get; set; }
        public String Img { get; set; }
        public int SoSanPham { get; set; }

        SanPhamDto()
        {

        }
        SanPhamDto(int IdSanPham, String TenSanPham, decimal Gia, String Img, int SoSanPham)
        {
            this.IdSanPham = IdSanPham;
            this.TenSanPham = TenSanPham;
            this.Gia = Gia;
            this.Img = Img;
            this.SoSanPham = SoSanPham;
        }
    }
}