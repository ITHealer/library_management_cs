using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLTV;

namespace DAL_QLTV
{
    public class DAL_MUONSACH : DBConnect
    {
        public DataTable getMuonSach()
        {
            SqlDataAdapter daSach = new SqlDataAdapter("SELECT * FROM MUONSACH", _conn);
            DataTable dtSach = new DataTable();
            daSach.Fill(dtSach);
            return dtSach;
        }

        // lấy danh sách độc giả mượn sách theo các trường thông tin mong muốn để hiển thị lên gridview
        public DataTable getMuonSach2()
        {
            SqlDataAdapter daSach = new SqlDataAdapter("SELECT a.MaSach, c.TenSach, a.MaDG, b.HoTen, a.NgayMuon, a.NgayTra FROM MUONSACH as a, DOCGIA as b, SACH as c WHERE a.MaDG = b.MaDG AND a.MaSach = c.MaSach", _conn);
            DataTable dtSach2 = new DataTable();
            daSach.Fill(dtSach2);
            return dtSach2;
        }

        // danh sách độc giả quá hạn + tiền phạt
        public DataTable getMuonSachQuaHan()
        {
            
            SqlDataAdapter daSach = new SqlDataAdapter("Select HoTen, N'Tiền phạt' = DATEDIFF(day, b.NgayMuon, b.NgayTra)*2000 from DOCGIA as a, MUONSACH as b where a.MaDG = b.MaDG and DATEDIFF(day, NgayMuon, NgayTra) > 7", _conn);
            DataTable dtSach3 = new DataTable();
            daSach.Fill(dtSach3);
            return dtSach3;
        }

        public bool themMuonSach(DTO_MuonSach s)
        {
            try
            {
                // Mở kết nối
                _conn.Open();

                // Query string - vì mình để TV_ID là identity (giá trị tự tăng dần) nên ko cần fải insert ID
                string SQL = string.Format("INSERT INTO MUONSACH(MaSach, MaDG, NgayMuon, NgayTra) VALUES (@ms , @mdg , @ngaymuon , @ngaytra)");

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                cmd.Parameters.AddWithValue("@ms", s.MaSach);
                cmd.Parameters.AddWithValue("@mdg", s.MaDG);
                cmd.Parameters.AddWithValue("@ngaymuon", s.NgayMuon);
                cmd.Parameters.AddWithValue("@ngaytra", s.NgayTra);
                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
            return false;
        }

        //Sửa
        public bool suaMuonSach(DTO_MuonSach sach)
        {
            try
            {
                // Mở kết nối
                _conn.Open();

                // Query string ; lỗi ngày
                string SQL = string.Format("UPDATE MUONSACH SET MaSach = @ms, NgayMuon = @ngaymuon, NgayTra = @ngaytra where MaDG = @mdg");
                
                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều)
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                cmd.Parameters.AddWithValue("@ms", sach.MaSach);
                cmd.Parameters.AddWithValue("@mdg", sach.MaDG);
                cmd.Parameters.AddWithValue("@ngaymuon", sach.NgayMuon);
                cmd.Parameters.AddWithValue("@ngaytra", sach.NgayTra);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
            return false;
        }

        public bool xoaMuonSach(string id, string dg)
        {
            try
            {
                // Mở kết nối
                _conn.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM MUONSACH WHERE MaSach = '{0}' AND MaDG = '{1}'", id, dg);
                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
            return false;
        }

        // xóa theo mã độc giả. Để xóa một độc giả cần xóa tất cả độc giả đó trong ds mượn
        public bool xoaMuonSach2(string dg)
        {
            try
            {
                // Mở kết nối
                _conn.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM MUONSACH WHERE MaDG = '{0}'", dg);
                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
            return false;
        }

        public bool xoaMuonSach3(string s)
        {
            try
            {
                // Mở kết nối
                _conn.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM MUONSACH WHERE MaSach = '{0}'", s);
                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                _conn.Close();
            }
            return false;
        }
    }
}
