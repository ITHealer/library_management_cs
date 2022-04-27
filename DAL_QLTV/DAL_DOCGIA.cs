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
            //try
            //{
            // Ket noi
            _conn.Open();

            // Query string - vì mình để TV_ID là identity (giá trị tự tăng dần) nên ko cần fải insert ID
            string SQL = string.Format("INSERT INTO DOCGIA(MaDG , HoTen , GioiTinh , NgaySinh) VALUES ( '{0}' , '{1}' , '{2}' , '{3}' )", s.MaDG, s.HoTen, s.GioiTinh, s.NgaySinh);

            // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
            SqlCommand cmd = new SqlCommand(SQL, _conn);
            //cmd.Parameters.Add("@ns", SqlDbType.DateTime);
            // Query và kiểm tra
            cmd.ExecuteNonQuery();
            return true;
            _conn.Close();
        }
        //catch (Exception e)
        //{

        //}
        //finally
        //{
        //    // Dong ket noi
        //    _conn.Close();
        //}

        //return false;
    

        //Sửa
        public bool suaDocGia(DTO_DocGia dg)
        {
            try
            {
                // Ket noi
                _conn.Open();

                // Query string
                string SQL = string.Format("UPDATE DOCGIA SET HoTen = '{0}', GioiTinh = '{1}', NgaySinh = '{2}' WHERE MaSach = '{3}'", dg.HoTen, dg.GioiTinh, dg.NgaySinh, dg.MaDG);

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
