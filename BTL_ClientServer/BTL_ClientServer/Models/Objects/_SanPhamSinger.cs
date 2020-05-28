using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTL_ClientServer.Models.Entity;

namespace BTL_ClientServer.Models.Objects
{
    public class _SanPhamSinger
    {
        public int Id { get; set; }

        public string TenSanPham { get; set; }

        public decimal? Gia { get; set; }
        
        public string DoiTuongSuDung { get; set; }

        public decimal? KichThuocBeMat { get; set; }
        
        public string ChatLieuMatKinh { get; set; }
        
        public string ChatLieuDay { get; set; }

        public decimal? DoDay { get; set; }

        public decimal? DoDai { get; set; }

        public decimal? DoRongCuaDay { get; set; }
        
        public string KieuKhoa { get; set; }

        public string ChatLieuVoMay { get; set; }

        public string May { get; set; }

        public string KhaNangChiuNuoc { get; set; }

        public string TenThuongHieu { get; set; }

        public string ThongTinThuongHieu { get; set; }

        public string MoTaThuongHieu { get; set; }
        
    }
}