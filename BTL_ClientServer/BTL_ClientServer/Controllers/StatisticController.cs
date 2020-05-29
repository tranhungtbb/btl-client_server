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
    }
}