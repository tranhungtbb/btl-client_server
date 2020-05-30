using BTL_ClientServer.Models.Dto;
using BTL_ClientServer.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_ClientServer.Controllers
{
    public class StatisticController : Controller
    {
        DBModel db = new DBModel();
        // GET: Statistic
        public ActionResult Index()
        {
            return View();
        }
        //tìm kiếm
        public ActionResult SearchByName(String searchText)
        {
            var listSanPham = db.SanPhams.Where(n => n.TenSanPham.Contains(searchText)).ToList();
            var count = listSanPham.Count();
            if (count > 0)
            {
                ViewBag.count = count;
                ViewBag.listSanPham = listSanPham;
            }
            else
            {
                ViewBag.count = 0;
            }

            return View();
        }

        //tìm kiếm theo nhiều giá trị
        public ActionResult ViewTimKiem()
        {
            var listThuongHieu = db.ThuongHieus.ToList();
            ViewBag.listThuongHieu = listThuongHieu;

            var listLoaiSanPham = db.LoaiSanPhams.ToList();
            ViewBag.loaiSanPham = listLoaiSanPham;

            return PartialView();
        }

        public ActionResult KetQuaTimKiem(String giatu, String giaden, int idth, int idlsp, int khoanggia)
        {
            System.Diagnostics.Debug.WriteLine(giatu + " - " + giaden + " - " + idth + "- " + idlsp);
            if ("" == giatu || "" == giaden)
            {
                switch (khoanggia)
                {
                    case 1:
                        giatu = "0";
                        giaden = "1000000";
                        break;
                    case 2:
                        giatu = "1000000";
                        giaden = "2000000";
                        break;
                    case 3:
                        giatu = "2000000";
                        giaden = "3000000";
                        break;
                    case 4:
                        giatu = "3000000";
                        giaden = "4000000";
                        break;
                    case 5:
                        giatu = "4000000";
                        giaden = "5000000";
                        break;
                    case 6:
                        giatu = "5000000";
                        giaden = "20000000";
                        break;
                }
            }
            //   decimal giadown = Decimal.Parse(giatu);
            //    decimal giaup = Decimal.Parse(giaden);
            SqlParameter[] para =
            {
                new SqlParameter("@duoi",System.Data.SqlDbType.VarChar,50){Value= giatu},
                new SqlParameter("@tren",System.Data.SqlDbType.VarChar,50){Value= giaden},
                new SqlParameter("@thuonghieu",System.Data.SqlDbType.VarChar,50){Value= idth.ToString()},
                new SqlParameter("@loaisanpham",System.Data.SqlDbType.VarChar,50){Value= idlsp.ToString()}
            };
            string query = "EXEC XemSanPhamGiaThuongHieuLoaiSanPham @duoi, @tren, @thuonghieu, @loaisanpham";
            var kq = db.Database.SqlQuery<SanPham>(query, para).ToList();

            var count = kq.Count();
            if (count > 0)
            {
                ViewBag.count = count;
                ViewBag.listSanPham = kq;
            }
            else
            {
                ViewBag.count = 0;

            }
            return View();
        }


        //laays danh sachs theo ngay
        [HttpGet]
        public ActionResult XemThongTinTheoNgay(int thang)
        {
            var kh = db.Database.SqlQuery<KhachHangDto>("select DATEPART(DAY,NgayTao) as Ngay,Id, MaKhachHang, TenKhachHang,count(ns.MaSanPham) as SoLuongOrder" +
                ",sum(ns.SoLuong) as SoLuongSanPham from NguoiDung_SanPham ns where DATEPART(MONTH, NgayTao) = " + thang + " group by ns.NgayTao, Id, MaKhachHang, TenKhachHang").ToList();
            var listOrderBySoLuong = kh.OrderBy(n => n.Ngay).ToList();
            kh.ForEach(e => { System.Diagnostics.Debug.WriteLine(e.TenKhachHang); });
            ViewBag.thang = thang;
            return View(listOrderBySoLuong);
        }

        [HttpGet]
        public ActionResult XemChiTietThongTin(int thang, int day, int idKhachHang)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@thang",System.Data.SqlDbType.VarChar,50){Value= thang.ToString()},
                 new SqlParameter("@day",System.Data.SqlDbType.VarChar,50){Value= day.ToString()},
                  new SqlParameter("@idKhachHang",System.Data.SqlDbType.VarChar,50){Value= idKhachHang.ToString()},

            };
            //var pId = new SqlParameter[] { ParameterName = "thang", Value = thang ; };

            string query = "EXEC XemThongKeChiTietKhachHang @thang, @day, @idKhachHang";
            var kq = db.Database.SqlQuery<ChiTietThongTin>(query, para).ToList();
            System.Diagnostics.Debug.WriteLine("thang = ", thang);
            foreach (ChiTietThongTin k in kq)
            {
                System.Diagnostics.Debug.WriteLine(k.TenSanPham);
            }
            return PartialView(kq.OrderBy(n => n.MaSanPham).ToList());
        }

        //chức năng vẽ biểu đồ thống kê
        //thống kê theo tiền thu nhập theo ngày và số lượng order theo ngày
        public ActionResult TestThongKe(int k)
        {
            System.Diagnostics.Debug.WriteLine("test thống kê , k =" + k);
            Detail detail = new Detail();
            var doituongmoi = db.HoaDons.Where(m => m.NgayTao.Value.Month == k)
                                        .GroupBy(a => a.NgayTao.Value.Day)

                                        .Select(a => new Detail { amount = a.Sum(b => (decimal?)b.TongTienPhaiTra) ?? 0, day = a.Key, count = a.Count() })

                                        .OrderBy(c => c.day).ToList();


            int[] dayOfMonth = new int[31];
            decimal[] valueOrderMonth = new decimal[31];
            int[] countOfMonth = new int[31];
            for (int i = 1; i < 31; i++)
            {
                dayOfMonth[i] = i;
                doituongmoi.ForEach(n =>
                {
                    if (n.day == i)
                    {
                        valueOrderMonth[i] = n.amount;
                        countOfMonth[i] = n.count;
                    }
                });
            }
            for (int iiii = 0; iiii < 31; iiii++)
            {
                System.Diagnostics.Debug.WriteLine(dayOfMonth[iiii] + " ---- " + valueOrderMonth[iiii] + " --- " + countOfMonth[iiii]);
            }

            ViewBag.i = dayOfMonth;
            ViewBag.ii = valueOrderMonth;
            ViewBag.iii = countOfMonth;

            //foreach (var i in doituongmoi)
            //{
            //    System.Diagnostics.Debug.WriteLine(i.day + " ----- " + i.amount + " --------" + i.count);
            //}

            ViewBag.thang = k;
            return View();

        }

        // xem khách hàng tiềm năng trong tháng -- dưới biểu đồ   :sắp xếp theo số sản phẩm mua
        [HttpGet]
        public ActionResult XemKhachHangTiemNangTrongThang(int thang)
        {
            var pId = new SqlParameter { ParameterName = "thang", Value = thang };
            string query = "EXEC XemTienVaHoaDonTrongThang @thang";
            var kq = db.Database.SqlQuery<KhachHangDto1>(query, pId).ToList();
            System.Diagnostics.Debug.WriteLine("thang = ", thang);
            foreach (KhachHangDto1 k in kq)
            {
                System.Diagnostics.Debug.WriteLine(k.TenKhachHang);
            }
            return PartialView(kq.OrderByDescending(n => n.SoLuong).ToList());
        }

        // sắp xếp theo số tiền trả
        [HttpGet]
        public ActionResult XemKhachHangTiemNangTrongThangTongTien(int thang)
        {
            var pId = new SqlParameter { ParameterName = "thang", Value = thang };
            string query = "EXEC XemTienVaHoaDonTrongThang @thang";
            var kq = db.Database.SqlQuery<KhachHangDto1>(query, pId).ToList();
            System.Diagnostics.Debug.WriteLine("thang = ", thang);
            foreach (KhachHangDto1 k in kq)
            {
                System.Diagnostics.Debug.WriteLine(k.TenKhachHang);
            }
            return PartialView(kq.OrderByDescending(n => n.TongTienDaTra).ToList());
        }

        // xem khách hàng tiềm năng ( all)
        [HttpGet]
        public ActionResult XemKhachHangTiemNang()
        {
            var kh = db.Database.SqlQuery<KhachHangDto1>("select kh.Id,kh.MaKhachHang,kh.TenKhachHang,kh.DiaChi,kh.Email,kh.GioiTinh,kh.NgaySinh, count(hd.IdKhachHang) SoLuong,sum(hd.TongTienPhaiTra) as TongTienDaTra from KhachHang kh join HoaDon hd on kh.Id = hd.IdKhachHang group by kh.Id, kh.MaKhachHang, kh.TenKhachHang, kh.DiaChi, kh.Email, kh.GioiTinh, kh.NgaySinh, kh.Id").ToList();
            var listOrderBySoLuong = kh.OrderByDescending(n => n.SoLuong).ToList();
            kh.ForEach(e => { System.Diagnostics.Debug.WriteLine(e.TenKhachHang); });

            return PartialView(listOrderBySoLuong);
        }

        // xem khách hàng tiềm năng tổng tiền ( all)
        [HttpGet]
        public ActionResult XemKhachHangTiemNangTT()
        {
            var kh = db.Database.SqlQuery<KhachHangDto1>("select kh.Id,kh.MaKhachHang,kh.TenKhachHang,kh.DiaChi,kh.Email,kh.GioiTinh,kh.NgaySinh, count(hd.IdKhachHang) SoLuong,sum(hd.TongTienPhaiTra) as TongTienDaTra from KhachHang kh join HoaDon hd on kh.Id = hd.IdKhachHang group by kh.Id, kh.MaKhachHang, kh.TenKhachHang, kh.DiaChi, kh.Email, kh.GioiTinh, kh.NgaySinh, kh.Id").ToList();
            var listOrderBySoLuong = kh.OrderByDescending(n => n.TongTienDaTra).ToList();
            kh.ForEach(e => { System.Diagnostics.Debug.WriteLine(e.TenKhachHang); });

            return PartialView(listOrderBySoLuong);
        }

        //lấy danh sách sản phẩm được mua nhiều nhất trong 1 tháng nào đó
        [HttpGet]
        public ActionResult XemSanPhamBanChayTrongThang(int thang)
        {
            var pId = new SqlParameter { ParameterName = "thang", Value = thang };
            string query = "EXEC XemSanPhamBanChayNhatTrongThang @thang";
            var kq = db.Database.SqlQuery<SanPhamDto>(query, pId).ToList();
            System.Diagnostics.Debug.WriteLine("thang = ", thang);
            foreach (SanPhamDto k in kq)
            {
                System.Diagnostics.Debug.WriteLine(k.TenSanPham);
            }
            return PartialView(kq.OrderByDescending(n => n.SoSanPham).ToList());
        }
        //lấy danh sách sản phẩm không được mua trong tháng nào đó
        [HttpGet]
        public ActionResult XemSanPhamKhongBanTrongThang(int thang)
        {
            var pId = new SqlParameter { ParameterName = "thang", Value = thang };
            string query = "EXEC XemSanPhamKhongBanTrongThang @thang";
            var kq = db.Database.SqlQuery<SanPham>(query, pId).ToList();
            System.Diagnostics.Debug.WriteLine("thang = ", thang);
            foreach (SanPham k in kq)
            {
                System.Diagnostics.Debug.WriteLine(k.TenSanPham);
            }
            return PartialView(kq.OrderByDescending(n => n.Gia).ToList());
        }
    }
}