using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL_QLTV
{
    public class DBConnect
    {
        protected SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-F1OLJ2J\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True");
    }
}
