using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_ClientServer.Models.Entity;

namespace BTL_ClientServer.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        private DBModel db = new DBModel();

        // GET: Admin/SanPham
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiSanPham).Include(s => s.ThuongHieu);
            return View(sanPhams.ToList());
        }

        // GET: Admin/SanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            ViewBag.IdLoaiSanPham = new SelectList(db.LoaiSanPhams, "Id", "TenLoaiSanPham");
            ViewBag.IdThuongHieu = new SelectList(db.ThuongHieus, "Id", "MaThuongHieu");
            return View();
        }

        // POST: Admin/SanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaSanPham,TenSanPham,Gia,DoiTuongSuDung,KichThuocBeMat,ChatLieuMatKinh,ChatLieuDay,DoDay,DoDai,DoRongCuaDay,KieuKhoa,ChatLieuVoMay,May,KhaNangChiuNuoc,GiamGia,IdThuongHieu,IdLoaiSanPham,NgayCapNhap")] SanPham sanPham, string tenanh)
        {
            if (ModelState.IsValid)
            {
                Image img = new Image();
                var IdImgMax = db.Images.Max(x => x.Id);
                img.Id = IdImgMax + 1;
                img.TenAnh = "";
                img.IdSanPham = sanPham.Id;
                db.Images.Add(img);
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLoaiSanPham = new SelectList(db.LoaiSanPhams, "Id", "TenLoaiSanPham", sanPham.IdLoaiSanPham);
            ViewBag.IdThuongHieu = new SelectList(db.ThuongHieus, "Id", "MaThuongHieu", sanPham.IdThuongHieu);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLoaiSanPham = new SelectList(db.LoaiSanPhams, "Id", "TenLoaiSanPham", sanPham.IdLoaiSanPham);
            ViewBag.IdThuongHieu = new SelectList(db.ThuongHieus, "Id", "MaThuongHieu", sanPham.IdThuongHieu);
            return View(sanPham);
        }

        // POST: Admin/SanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaSanPham,TenSanPham,Gia,DoiTuongSuDung,KichThuocBeMat,ChatLieuMatKinh,ChatLieuDay,DoDay,DoDai,DoRongCuaDay,KieuKhoa,ChatLieuVoMay,May,KhaNangChiuNuoc,GiamGia,IdThuongHieu,IdLoaiSanPham,NgayCapNhap")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLoaiSanPham = new SelectList(db.LoaiSanPhams, "Id", "TenLoaiSanPham", sanPham.IdLoaiSanPham);
            ViewBag.IdThuongHieu = new SelectList(db.ThuongHieus, "Id", "MaThuongHieu", sanPham.IdThuongHieu);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Search(String tenSanPham)
        {
            var listSanPham = db.SanPhams.Where(n => n.TenSanPham.Contains(tenSanPham)).ToList();
            //var listSanPham = db._SanPham.Where(n => n.TenSanPham.Contains(n1)).ToList();
            //var listSanPham = db.SanPhams.Where(n => n.TenSanPham.Contains(n1)).Where(n => n.Gia > 1000000).ToList();
            var soLuongSanPham = listSanPham.Count;
            ViewBag.soSP = soLuongSanPham;
            ViewBag.listSanPham = listSanPham;
            return View();
        }
    }
}
