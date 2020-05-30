namespace BTL_ClientServer.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            GioHangs = new HashSet<GioHang>();
            Images = new HashSet<Image>();
        }

        public int Id { get; set; }

        [StringLength(10)]
        public string MaSanPham { get; set; }

        [StringLength(100)]
        public string TenSanPham { get; set; }

        public decimal? Gia { get; set; }

        [StringLength(100)]
        public string DoiTuongSuDung { get; set; }

        public decimal? KichThuocBeMat { get; set; }

        [StringLength(200)]
        public string ChatLieuMatKinh { get; set; }

        [StringLength(100)]
        public string ChatLieuDay { get; set; }

        public decimal? DoDay { get; set; }

        public decimal? DoDai { get; set; }

        public decimal? DoRongCuaDay { get; set; }

        [StringLength(100)]
        public string KieuKhoa { get; set; }

        public string ChatLieuVoMay { get; set; }

        public string May { get; set; }

        public string KhaNangChiuNuoc { get; set; }

        public int? GiamGia { get; set; }

        public int? IdThuongHieu { get; set; }

        public int? IdLoaiSanPham { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCapNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Images { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        public virtual ThuongHieu ThuongHieu { get; set; }
    }
}
