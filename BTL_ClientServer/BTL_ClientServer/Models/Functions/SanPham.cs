using BTL_ClientServer.Models.Objects;
using BTL_ClientServer.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ClientServer.Models.Functions
{
    public class SanPham
    {
        DBModel db = new DBModel();

        public List<_SanPham> GetListProductDiscount()
        {
            List<_SanPham> a = null;
            a = db.Database.SqlQuery<_SanPham>("SanPhamGiamGia").Take(8).ToList();
            return a;
        }

        // san pham co trong nhieu hoa don nhat
        public List<_SanPham> GetListProductPopular(){
            List<_SanPham> a = null;
            a = db.Database.SqlQuery<_SanPham>("SanPhamPhoBien").Take(8).ToList();
            return a;
        }


        // mơi nhat
        public List<_SanPham> GetListProductNew()
        {
            List<_SanPham> a = null;
            a = db.Database.SqlQuery<_SanPham>("SanPhamMoi").Take(8).ToList();
            return a;
        }

        //san pham co soluong trong hoa don nhieu nhat
        public List<_SanPham> GetListProductBestSale()
        {
            List<_SanPham> a = null;
            a = db.Database.SqlQuery<_SanPham>("SanPhamBanChay").Take(8).ToList();
            return a;
        }

        // đắt nhất
        public List<_SanPham> GetListProductSpecial()
        {
            List<_SanPham> a = null;
            a = db.Database.SqlQuery<_SanPham>("SanPhamDacBiet").Take(8).ToList();
            return a;
        }

        public List<Image> GetImageByProductId(int? id)
        {
            List<Image> a = null;
            a = (from img in db.Images
                     where img.IdSanPham == id
                     select img).Take(4).ToList();
            return a;
        }

    }
}