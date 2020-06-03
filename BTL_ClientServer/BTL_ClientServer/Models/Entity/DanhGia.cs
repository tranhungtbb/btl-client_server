namespace BTL_ClientServer.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhGia")]
    public partial class DanhGia
    {
        public int Id { get; set; }

        public int? IdSanPham { get; set; }

        public int? IdKhachHang { get; set; }

        public string Comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
