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
    public class BUS_DOCGIA
    {
        DAL_DOCGIA dalDG = new DAL_DOCGIA();
        public DataTable getDocGia()
        {
            return dalDG.getDocGia();
        }
        public bool themDocGia(DTO_DocGia dg)
        {
            return dalDG.themDocGia(dg);
        }
        public bool suaDocGia(DTO_DocGia dg)
        {
            return dalDG.suaDocGia(dg);
        }
        public bool xoaDocGia(string id)
        {
            return dalDG.xoaDocGia(id);
        }
    }
}
