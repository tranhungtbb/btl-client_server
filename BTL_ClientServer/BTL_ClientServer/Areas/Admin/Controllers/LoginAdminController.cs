using BTL_ClientServer.Areas.Admin.Models;
using BTL_ClientServer.Common;
using BTL_ClientServer.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_ClientServer.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Admin/LoginAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginAdmin modle)           
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(modle.TenDangNhap, modle.MatKhau);
                if (result)
                {
                    var user = dao.GetByID(modle.TenDangNhap);

                    var userSession = new UserLogin();
                    userSession.UserID = user.Id;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng");
                }
            }
            return View("Index");           
        }
    }
}