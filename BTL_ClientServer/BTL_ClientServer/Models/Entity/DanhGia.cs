namespace BTL_ClientServer.Models.Entity
{
    using BTL_ClientServer.Models.Entity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhGia")]
    public partial class DanhGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhGia()
        {
            DanhGia1 = new HashSet<DanhGia>();
        }

        public int Id { get; set; }

        public int? IdSanPham { get; set; }

        public int? IdKhachHang { get; set; }

        public int? IdDanhGia { get; set; }

        public string Comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGia1 { get; set; }

        public virtual DanhGia DanhGia2 { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
