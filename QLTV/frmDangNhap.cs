using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QLTV;
using BUS_QLTV;
namespace QLTV
{
    public partial class frmDangNhap : Form
    {
        BUS_TAIKHOAN busTK = new BUS_TAIKHOAN();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassWord.Text.Trim();
            
            try
            {
                if(busTK.checkLogin(username, password) == 1){
                    //frmMain f = new frmMain();
                    //f.ShowDialog();
                        frmMain f = new frmMain();
                        f.ShowDialog();
                    
                }
                else if(busTK.checkLogin(username, password) == 2)
                {
                    frmQLSach f = new frmQLSach();
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập/Mật khẩu không hợp lệ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL!");
                return;
            }
            finally
            {
                
            }
        }
    }
}
