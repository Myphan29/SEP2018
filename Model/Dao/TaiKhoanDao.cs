using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    public class TaiKhoanDao
    {
        FingetPrintDbContext db = null;
        public TaiKhoanDao()
        {
            db = new FingetPrintDbContext();
        }
        public string Insert(TaiKhoan entity)
        {
            db.TaiKhoans.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public TaiKhoan GetByID(string userName)
        {
            return db.TaiKhoans.SingleOrDefault(x=>x.TenTK==userName);
        }
        public bool Login(string userName,string passWord)
        {
            var result = db.TaiKhoans.Count(x => x.TenTK == userName && x.matkhau == passWord);
            if (result > 0)
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
