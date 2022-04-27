using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class DTO_TaiKhoan
    {
        private string _TenDangNhap;
        private string _MatKhau;
        private int _Quyen;

        public DTO_TaiKhoan(string text, string text1) { }

        public DTO_TaiKhoan(string tdn, string mk, int quyen)
        {
            this.TenDangNhap = tdn;
            this.MatKhau = mk;
            this.Quyen = quyen;
        }
        public string TenDangNhap { get => _TenDangNhap; set => _TenDangNhap = value; }
        public string MatKhau { get => _MatKhau; set => _MatKhau = value; }
        public int Quyen { get => _Quyen; set => _Quyen = value; }
    }
}
