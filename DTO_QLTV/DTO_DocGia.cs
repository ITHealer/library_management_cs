using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class DTO_DocGia
    {
        private string _MaDG;
        private string _HoTen;
        private bool _GioiTinh;
        private DateTime _NgaySinh;

        public DTO_DocGia() { }

        public DTO_DocGia(string maDG, string ht, bool gt, DateTime ngaySinh)
        {
            this.MaDG = maDG;
            this.HoTen = ht;
            this.GioiTinh = gt;
            this.NgaySinh = ngaySinh;
        }

        public string MaDG { get => _MaDG; set => _MaDG = value; }
        public string HoTen { get => _HoTen; set => _HoTen = value; }
        public bool GioiTinh { get => _GioiTinh; set => _GioiTinh = value; }
        public DateTime NgaySinh { get => _NgaySinh; set => _NgaySinh = value; }
    }
}
