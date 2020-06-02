using BTL_ClientServer.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ClientServer.Models.Functions
{
    public class GioHang
    {
        DBModel db = new DBModel();
        public List<Entity.GioHang> getListGioHang(int Id)
        {
            List<Entity.GioHang> a = null;
            a = (from gh in db.GioHangs
                where gh.IdKhachHang == Id
                orderby gh.IdSanPham
                select gh).ToList();
            return a;
        }
        
    }
}