using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class DTO_Sach
    {
        private string _MaSach;
        private string _TenSach;
        private string _NXB;

        public DTO_Sach()
        {

        }

        public DTO_Sach(string maSach, string tenSach, string nxb) {
            this.MaSach = maSach;
            this.TenSach = tenSach;
            this.NXB = nxb;
        }

        public string MaSach { get => _MaSach; set => _MaSach = value; }
        public string TenSach { get => _TenSach; set => _TenSach = value; }
        public string NXB { get => _NXB; set => _NXB = value; }
    }
}
