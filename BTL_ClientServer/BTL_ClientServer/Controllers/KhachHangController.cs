using BTL_ClientServer.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_ClientServer.Controllers
{
    public class KhachHangController : Controller
    {
        DBModel db = new DBModel();
        [HttpGet]
        public ActionResult DangKi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKi(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                var idMax = db.KhachHangs.Max(y => y.Id);
                Random random = new Random();
                int num = random.Next();
                kh.Id = idMax + 1;
                kh.MaKhachHang = num.ToString();
                db.KhachHangs.Add(kh);
                db.SaveChanges();
            }

            return Redirect("/Home/Index");
        }





        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f,string URL)
        {
            string email = f.Get("email").ToString();
            string matkhau = f.Get("password").ToString();
            List<string> err = new List<string>();
            ViewData["ErrDangNhap"] = err;
            KhachHang kh = db.KhachHangs.Where(x => x.Email == email).SingleOrDefault();
            if (kh == null)
            {
                err.Add("Không tồn tại khách hàng!");
                return View("DangNhap");

            }
            if (kh.MatKhau != matkhau)
            {
                err.Add("Mật khẩu không đúng!");
                return View("DangNhap");
            }
            ViewData["ErrDangNhap"] = err;

            HttpCookie userInfo = new HttpCookie("userInfo");
            userInfo["UserId"] = kh.Id.ToString();
            userInfo.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(userInfo);

            return Redirect("/Home/Index");
        }


    }
}