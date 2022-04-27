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
    public class BUS_MUONSACH
    {
        DAL_MUONSACH dalSach = new DAL_MUONSACH();
        public DataTable getMuonSach()
        {
            return dalSach.getMuonSach();
        }
        public bool themMuonSach(DTO_MuonSach sach)
        {
            return dalSach.themMuonSach(sach);
        }
        public bool suaMuonSach(DTO_MuonSach sach)
        {
            return dalSach.suaMuonSach(sach);
        }
        public bool xoaMuonSach(string id, string dg)
        {
            return dalSach.xoaMuonSach(id, dg);
        }
    }
}
