namespace BTL_ClientServer.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string TenAnh { get; set; }

        public int? IdSanPham { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
