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
    public class DAL_TAIKHOAN : DBConnect
    {
        public DataTable getTaiKhoan()
        {
            SqlDataAdapter daTK = new SqlDataAdapter("SELECT * FROM DangNhap", _conn);
            DataTable dtTK = new DataTable();
            daTK.Fill(dtTK);
            return dtTK;
        }

        public int checkLogin(string user, string pass)
        {
            SqlDataReader rdr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select * from DangNhap", _conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if ((user == rdr["TenDangNhap"].ToString().Trim()) && (pass == rdr["MatKhau"].ToString().Trim()))
                    {
                        int q = int.Parse(rdr["Quyen"].ToString().Trim());
                        if (q == 0)
                        {
                            return 1;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (_conn != null)
                {
                    _conn.Close();
                }
            }
            return 0;
        }

        public bool themTaiKhoan(DTO_TaiKhoan s)
        {
            try
            {
                // Ket noi
                _conn.Open();

                // Query string - vì mình để TV_ID là identity (giá trị tự tăng dần) nên ko cần fải insert ID
                string SQL = string.Format("INSERT INTO DangNhap(TenDangNhap, MatKhau, Quyen) VALUES ('{0}', '{1}', '{2}')", s.TenDangNhap, s.MatKhau, s.Quyen);
                
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

        public bool suaTaiKhoan(DTO_TaiKhoan tk)
        {
            try
            {
                // Ket noi
                _conn.Open();

                // Query string
                string SQL = string.Format("UPDATE DangNhap SET MatKhau = '{0}', Quyen = '{1}' WHERE TenDangNhap = '{2}'", tk.MatKhau, tk.Quyen, tk.TenDangNhap);

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

        public bool xoaTaiKhoan(string tdn)
        {
            try
            {
                // Ket noi
                _conn.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM DangNhap WHERE TenDangNhap = '{0}'", tdn);
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
