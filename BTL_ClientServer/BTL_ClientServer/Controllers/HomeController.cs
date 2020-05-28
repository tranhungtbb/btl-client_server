using BTL_ClientServer.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_ClientServer.Models.Functions;
using BTL_ClientServer.Models.Objects;

namespace BTL_ClientServer.Controllers
{
    public class HomeController : Controller
    {
        DBModel db = new DBModel();
        public ActionResult Index()
        {
            // list thương hiệu
            ViewData["_Trademark"] = db.ThuongHieus.ToList();
            // list pro xuất hiện trong hóa đơn nhiều nhất
            ViewData["_ProductPopular"] = (new Models.Functions.SanPham()).GetListProductPopular();
            // list pro có số lượng bán ra trong hóa đơn nhiều nhất
            ViewData["_ProductNew"] = (new Models.Functions.SanPham()).GetListProductNew();
            // % sale max
            ViewData["_ProductSale"] = (new Models.Functions.SanPham()).GetListProductBestSale();
            // giá max
            ViewData["_ProductSpecial"] = (new Models.Functions.SanPham()).GetListProductSpecial();

            //
            var model = (new Models.Functions.SanPham()).GetListProductDiscount();
            return View("Index",model);
        }
    }
}