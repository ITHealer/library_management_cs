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
    public class DAL_DOCGIA : DBConnect
    {
        public DataTable getDocGia()
        {
            SqlDataAdapter daDG = new SqlDataAdapter("SELECT * FROM DOCGIA", _conn);
            DataTable dtDocGia = new DataTable();
            daDG.Fill(dtDocGia);
            return dtDocGia;
        }

        public bool themDocGia(DTO_DocGia s)
        {
            try
            {
                // Ket noi
                _conn.Open();

                // Query string - vì mình để TV_ID là identity (giá trị tự tăng dần) nên ko cần fải insert ID
                string SQL = "INSERT INTO DOCGIA(HoTen, GioiTinh, ngaysinh) VALUES (@ht, @gt,@ns)";

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                cmd.Parameters.AddWithValue("@ht", s.HoTen);
                cmd.Parameters.AddWithValue("@gt", s.GioiTinh);
                cmd.Parameters.AddWithValue("@ns", s.NgaySinh);
            // Query và kiểm tra
            if (cmd.ExecuteNonQuery()>0)
                    return true;
                _conn.Close();

            }
            catch (Exception e)
            {

            }
            finally
            {
                //  Dong ket noi
                _conn.Close();
            }

            return false;
        }

            //Sửa
            public bool suaDocGia(DTO_DocGia dg)
        {
            try
            {
                // Ket noi
                _conn.Open();

                int ma = Convert.ToInt32(dg.MaDG);
                // Query string
                string SQL = string.Format("UPDATE DOCGIA SET HoTen = @ht, GioiTinh = @gt, NgaySinh = @ns WHERE MaDG = '{0}'", ma);

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, _conn);
                cmd.Parameters.AddWithValue("@ht", dg.HoTen);
                cmd.Parameters.AddWithValue("@gt", dg.GioiTinh);
                cmd.Parameters.AddWithValue("@ns", dg.NgaySinh);
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

        public bool xoaDocGia(string id)
        {
            try
            {
                // Ket noi
                _conn.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM DOCGIA WHERE MaDG = '{0}'", id);
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
