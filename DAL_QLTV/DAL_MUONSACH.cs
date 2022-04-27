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

        public bool themMuonSach(DTO_MuonSach s)
        {
            try
            {
                // Ket noi
                _conn.Open();

                // Query string - vì mình để TV_ID là identity (giá trị tự tăng dần) nên ko cần fải insert ID
                string SQL = string.Format("INSERT INTO MUONSACH(MaSach, MaDG, NgayMuon, NgayTra) VALUES ('{0}' , '{1}' , '{2}' , '{3}')", s.MaSach, s.MaDG, s.NgayMuon, s.NgayTra);

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

        //Sửa
        public bool suaMuonSach(DTO_MuonSach sach)
        {
            try
            {
                // Ket noi
                _conn.Open();

                // Query string
                string SQL = string.Format("UPDATE MUONSACH SET NgayMuon = '{0}', NgayTra = '{1}' WHERE MaSach = '{2}' AND MaDG = '{3}'", sach.NgayMuon, sach.NgayTra, sach.MaSach, sach.MaDG);

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

        public bool xoaMuonSach(string id, string dg)
        {
            try
            {
                // Ket noi
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
    }
}
