using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ClientServer.Models.Objects
{
    public class _SanPham
    {
        public int Id { get; set; }

        public string TenSanPham { get; set; }

        public decimal Gia { get; set; }

        public int GiamGia { get; set; }

    }
}