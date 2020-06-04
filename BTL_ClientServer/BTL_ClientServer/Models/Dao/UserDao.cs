using BTL_ClientServer.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_ClientServer.Models.Dao
{
    public class UserDao
    {
        DBModel db = null;

        public UserDao()
        {
            db = new DBModel();
        }

        public int Insert (NguoiDung entity)
        {
            db.NguoiDungs.Add(entity);
            db.SaveChanges();
            return entity.Id; 
        }
        // lay 1 ban ghi don theo cai userName truyen vao
        public NguoiDung GetByID(string userName)
        {
            return db.NguoiDungs.SingleOrDefault(x=>x.TenDangNhap == userName);
        }

        public bool Login(string userName, string passWork)
        {
            var result = db.NguoiDungs.Count(x => x.TenDangNhap == userName && x.MatKhau == passWork);
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}