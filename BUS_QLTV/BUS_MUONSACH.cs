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

        // Lấy danh sách độc giả mượn sách
        public DataTable getMuonSach()
        {
            return dalSach.getMuonSach();
        }

        // Lấy danh sách độc giả mượn sách theo các trường thông tin mong muốn
        public DataTable getMuonSach2()
        {
            return dalSach.getMuonSach2();
        }

        // Lấy danh sách độc giả mượn sách quá hạn 7 ngày + tiền phạt = số ngày quá hạn * 2000
        public DataTable getMuonSachQuaHan()
        {
            return dalSach.getMuonSachQuaHan();
        }
        public bool themMuonSach(DTO_MuonSach sach)
        {
            return dalSach.themMuonSach(sach);
        }
        public bool suaMuonSach(DTO_MuonSach sach)
        {
            return dalSach.suaMuonSach(sach);
        }

        // Xóa 1 dòng mượn sách trong frmQLMuonSach
        public bool xoaMuonSach(string id, string dg)
        {
            return dalSach.xoaMuonSach(id, dg);
        }

        // Được gọi khi xóa một độc giả mà độc giả đó xuất hiện trong danh sách mượn sách
        // thì xóa dòng có chứa tên độc giả đó trong danh sách mượn sách trước khi xóa độc giả
        public bool xoaMuonSach2(string dg)
        {
            return dalSach.xoaMuonSach2(dg);
        }

        // Được gọi khi xóa một cuốn sách mà cuốn sách đó xuất hiện trong danh sách mượn sách
        // thì xóa dòng có chứa tên cuốn sách đó trong danh sách mượn sách trước khi xóa sách
        public bool xoaMuonSach3(string id)
        {
            return dalSach.xoaMuonSach3(id);
        }
    }
}
