namespace BTL_ClientServer.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        public int Id { get; set; }

        public int? IdSanPham { get; set; }

        public int? IdKhachHang { get; set; }

        public int Soluong { get; set; }

        public decimal? Gia { get; set; }

        public int? GiamGia { get; set; }

        public decimal? ThanhTien {
            get { return Soluong * Gia * (100-GiamGia)/100; }
        } 

        [StringLength(50)]
        public string TenSanPham { get; set; }

        [StringLength(50)]
        public string ThuongHieu { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
