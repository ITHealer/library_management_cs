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
    public class BUS_SACH
    {
        DAL_SACH dalSach = new DAL_SACH();
        public DataTable getSach()
        {
            return dalSach.getSach();
        }

        // tìm kiếm sách
        public DataTable timKiem(string sach)
        {
            return dalSach.timKiem(sach);
        }
        public bool themSach(DTO_Sach sach)
        {
            return dalSach.themSach(sach);
        }
        public bool suaSach(DTO_Sach sach)
        {
            return dalSach.suaSach(sach);
        }
        public bool xoaSach(string id)
        {
            return dalSach.xoaSach(id);
        }
    }
}
