using BTL_ClientServer.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_ClientServer.Controllers
{
    public class GioHangController : Controller
    {
        DBModel db = new DBModel();
        // GET: GioHang
        public ActionResult Index()
        {
            ViewBag._total = Total();
            List<GioHang> a = LayGioHang();
            return View(a);
        }
        public ActionResult GioHangSmall()
        {
            List<GioHang> a = LayGioHang();
            ViewBag._count = sumCount();
            ViewBag._total = Total();
            return PartialView("GioHangSmall",a);
        }
        public List<Models.Entity.GioHang> LayGioHang()
        {
            List<Models.Entity.GioHang> listGioHang;
            var cookiesUser = Request.Cookies["userInfo"];
            if (cookiesUser != null)
            {
                int userId = Convert.ToInt32(Request.Cookies["userInfo"].Value);
                listGioHang = (new Models.Functions.GioHang()).getListGioHang(userId);
                return listGioHang;
            }
            else
            {
                listGioHang = Session["GioHang"] as List<Models.Entity.GioHang>;
                if (listGioHang == null)
                {
                    listGioHang = new List<Models.Entity.GioHang>();
                    Session["GioHang"] = listGioHang;
                }
                return listGioHang;
            }
        }
        public ActionResult AddGioHang(int idSp , string URL)
        {
            List<GioHang> listGioHang = new List<GioHang>();
            if (Request.Cookies["userInfo"] != null)
            {
                var userInfo = Request.Cookies["userInfo"];
                int idKh = int.Parse(userInfo.Value);
                GioHang item = (from gh in db.GioHangs
                           where gh.IdSanPham == idSp
                           where gh.IdKhachHang == idKh
                           select gh).SingleOrDefault();
                if (item == null)
                {
                    GioHang newItem = new GioHang();
                    var idMax = db.GioHangs.Max(x => x.Id);

                    newItem.Id = idMax + 1;
                    newItem.IdKhachHang = idKh;
                    newItem.Soluong = 1;
                    newItem.IdSanPham = idSp;
                    db.GioHangs.Add(newItem);
                    db.SaveChanges();
                }
                else
                {
                    item.Soluong++;
                    db.SaveChanges();
                }
                return Redirect(URL);

            }
            else
            {
                listGioHang = LayGioHang();
                GioHang gh = listGioHang.Find(x => x.IdSanPham == idSp);
                if(gh == null)
                {
                    GioHang newItem = new GioHang();
                    var idMax = db.GioHangs.Max(x => x.Id);
                    SanPham s = (from sp in db.SanPhams where sp.Id == idSp select sp).SingleOrDefault();

                    newItem.Id = idMax + 1;
                    newItem.Gia = s.Gia;
                    newItem.Soluong = 1;
                    newItem.TenSanPham = s.TenSanPham;
                    newItem.GiamGia = s.GiamGia;
                    newItem.IdSanPham = idSp;
                    listGioHang.Add(newItem);
                }
                else{
                    gh.Soluong++;


                }
                return Redirect(URL);
            }
        }

        public ActionResult UpdateGioHang(int idSp, FormCollection f)
        {
            
            if (Request.Cookies["userInfo"] != null)// đã đăng nhập
            {
                var userInfo = Request.Cookies["userInfo"];
                int idkh = int.Parse(userInfo.Value); 
                GioHang itemGH = (from gh in db.GioHangs
                             where gh.IdKhachHang == idkh
                             where gh.IdSanPham == idSp
                             select gh).SingleOrDefault();

                itemGH.Soluong = int.Parse(f["txtSoLuong"].ToString());

                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                List<GioHang> list = LayGioHang();
                GioHang sp = list.Where(x => x.IdSanPham == idSp).SingleOrDefault();
                if (sp != null)
                {
                    sp.Soluong = int.Parse(f["txtSoLuong"].ToString());
                }
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult RemoteGioHang(int id) // id gio hang
        {
            List<GioHang> listGioHang = LayGioHang();
            if (Request.Cookies["userInfo"] != null)// đã đăng nhập
            {
                GioHang item = (from gh in db.GioHangs where gh.Id == id select gh).SingleOrDefault();
                if (item != null)
                {
                    db.GioHangs.Remove(item);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                var item = listGioHang.Find(x => x.Id == id);
                listGioHang.Remove(item);
                return RedirectToAction("Index");
            }
        }
        public decimal? Total()
        {
            decimal? res =0;
            List<GioHang> listGioHang = LayGioHang();
            for(var i =0; i< listGioHang.Count; i++)
            {
                res += listGioHang[i].ThanhTien;
            }

            return res;
        }
        public int sumCount()
        {
            int res = 0;
            List<GioHang> listGioHang = LayGioHang();
            for (var i = 0; i < listGioHang.Count; i++)
            {
                res += listGioHang[i].Soluong;
            }

            return res;
        }



        public ActionResult DatHang()
        {
            var cookiesUser = Request.Cookies["userInfo"];
            if (cookiesUser == null)
            {
                return Redirect("/KhachHang/DangNhap");
            }
            else
            {
                List<GioHang> listGioHang = LayGioHang();
                int idKh = Convert.ToInt16(cookiesUser.Value);
                var idHDMax = db.HoaDons.Max(x => x.Id);
                HoaDon hoadon = new HoaDon();
                if (idHDMax == 0)
                {
                    idHDMax = 1;
                }

                hoadon.Id = idHDMax + 1;
                hoadon.NgayTao = DateTime.Now;

                db.HoaDons.Add(hoadon);
                
                foreach(var i in listGioHang)
                {
                    ChiTietHoaDon ct = new ChiTietHoaDon();
                    ct.IdHoaDon = hoadon.Id;
                    ct.IdSanPham = (int)i.IdSanPham;
                    ct.SoLuong = i.Soluong;
                    db.ChiTietHoaDons.Add(ct);

                    var remoteGioHang = (from gh in db.GioHangs
                                         where gh.IdKhachHang == i.IdKhachHang
                                         where gh.IdSanPham == i.IdSanPham
                                         select gh).SingleOrDefault();
                    db.GioHangs.Remove(remoteGioHang);
                }
                db.SaveChanges();
                ViewBag._success = "Đặt hàng thành công!";
                return RedirectToAction("Index");

            }
        }
    }
}