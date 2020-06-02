using BTL_ClientServer.Models.Entity;
using BTL_ClientServer.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_ClientServer.Controllers
{
    public class ProductController : Controller
    {
        DBModel db = new DBModel();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SingleProduct(int id)
        {
            ViewData["_listImageById"] = (new BTL_ClientServer.Models.Functions.SanPham()).GetImageByProductId(id);
            var model = (from sp in db.SanPhams
                         join th in db.ThuongHieus on sp.IdThuongHieu equals th.Id
                         where sp.Id == id
                         select new _SanPhamSinger {
                             Id = sp.Id,
                             TenSanPham = sp.TenSanPham,
                             Gia = sp.Gia,
                             DoiTuongSuDung = sp.DoiTuongSuDung,
                             KichThuocBeMat = sp.KichThuocBeMat,
                             ChatLieuMatKinh = sp.ChatLieuMatKinh,
                             ChatLieuDay = sp.ChatLieuDay,
                             DoDay = sp.DoDay,
                             DoDai = sp.DoDai,
                             DoRongCuaDay = sp.DoRongCuaDay,
                             KieuKhoa = sp.KieuKhoa,
                             ChatLieuVoMay = sp.ChatLieuVoMay,
                             May = sp.May,
                             KhaNangChiuNuoc = sp.KhaNangChiuNuoc,

                             TenThuongHieu = th.TenThuongHieu,
                             ThongTinThuongHieu = th.ThongTinThuongHieu,
                             MoTaThuongHieu = th.MoTa
                            }).SingleOrDefault();

            var relatedProducts = Request.Cookies["relatedProducts"];
            if (relatedProducts == null)
            {
                relatedProducts = new HttpCookie("relatedProducts");
            }
            relatedProducts.Expires = DateTime.Now.AddDays(30);
            relatedProducts.Values[id.ToString()] = id.ToString();
            Response.Cookies.Add(relatedProducts);

            var res = Request.Cookies["relatedProducts"].Values.AllKeys.Select(key => int.Parse(key)).ToList();

            //List<SanPham> list = new List<SanPham>();
            //SanPham i = db.SanPhams.Where(x=>x.Id==id).SingleOrDefault();
            //list.Add(i);
            //var r = String.Join(",", list);
            //var cookieListSP = new HttpCookie("aaa", r);
            //cookieListSP.Expires = DateTime.Now.AddDays(1);
            //Response.Cookies.Add(cookieListSP);

            //List<string> LIST = Request.Cookies["aaa"].Value.Split(',').ToList();

            
            ViewData["relatedProducts"] = db.SanPhams.Where(x => res.Contains(x.Id)).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult postComment(DanhGia dg)
        {
            var idMax = db.DanhGias.Max(x => x.Id);
            if(idMax == 0)
            {
                dg.Id = 1;
            }
            dg.Id = idMax + 1;
            dg.Ngay = DateTime.Now;
            db.DanhGias.Add(dg);
            db.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        public JsonResult getComment(int idSp)
        {
            List<_DanhGia> s = new List<_DanhGia>();
            s = (from dg in db.DanhGias
                join kh in db.KhachHangs on dg.IdKhachHang equals kh.Id
                where dg.IdSanPham == idSp
                select new _DanhGia
                {
                    Id = dg.Id,
                    TenKhachHang = kh.TenKhachHang,
                    IdSanPham = dg.IdSanPham,
                    Ngay = dg.Ngay,
                    Comment = dg.Comment
                })
                .ToList();
            return Json(s, JsonRequestBehavior.AllowGet);
        }


    }
}