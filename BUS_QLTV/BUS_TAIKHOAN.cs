using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QLTV;
using DTO_QLTV;

namespace BUS_QLTV
{
    public class BUS_TAIKHOAN
    {
        DAL_TAIKHOAN dalTaiKhoan = new DAL_TAIKHOAN();
        public DataTable getTaiKhoan()
        {
            return dalTaiKhoan.getTaiKhoan();
        }
        public bool themTaiKhoan(DTO_TaiKhoan tk)
        {
            return dalTaiKhoan.themTaiKhoan(tk);
        }
        public bool suaTaiKhoan(DTO_TaiKhoan tk)
        {
            return dalTaiKhoan.suaTaiKhoan(tk);
        }
        public bool xoaTaiKhoan(string tk)
        {
            return dalTaiKhoan.xoaTaiKhoan(tk);
        }

        // kiểm tra đăng nhập
        public int checkLogin(string user, string pass)
        {
            return dalTaiKhoan.checkLogin(user, pass);
        }
    }
}
