namespace BTL_ClientServer.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            GioHangs = new HashSet<GioHang>();
            HoaDons = new HashSet<HoaDon>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string MaKhachHang { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string TenKhachHang { get; set; }

        [StringLength(30)]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string TenDangNhap { get; set; }

        [StringLength(30)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string MatKhau { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public DateTime? NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        [StringLength(100)]
        [Display(Name = "Điạ chỉ")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string DiaChi { get; set; }

        [StringLength(20)]
        [Phone]
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
