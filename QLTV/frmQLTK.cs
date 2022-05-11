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
    public partial class frmQLTK : Form
    {
        BUS_TAIKHOAN busTK = new BUS_TAIKHOAN();
        public frmQLTK()
        {
            InitializeComponent();
        }
       
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "" && txtPass.Text != "")
            {
                // Tạo DTO
                DTO_TaiKhoan sv = new DTO_TaiKhoan(txtUser.Text, txtPass.Text, Int32.Parse(cbbQuyen.Text)); // Vì ID tự tăng nên để ID số gì cũng dc

                // Thêm
                if (busTK.themTaiKhoan(sv))
                {
                    MessageBox.Show("Thêm thành công");
                    dtgvTK.DataSource = busTK.getTaiKhoan(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Thêm ko thành công");
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập đầy đủ");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dòng nào trong datagridview chưa
            //https://docs.microsoft.com/vi-vn/dotnet/desktop/winforms/controls/selected-cells-rows-and-columns-datagridview?view=netframeworkdesktop-4.8
            Int32 selectedCellCount =
                            dtgvTK.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
            if (txtUser.Text != "" && txtPass.Text != "")
                {
                    // Tạo DTO
                    DTO_TaiKhoan tv = new DTO_TaiKhoan(txtUser.Text, txtPass.Text, Int32.Parse(cbbQuyen.Text)); 

                    // Sửa
                    if (busTK.suaTaiKhoan(tv))
                    {
                        MessageBox.Show("Sửa thành công");
                        dtgvTK  .DataSource = busTK.getTaiKhoan(); // refresh datagridview
                    }
                    else
                    {
                        MessageBox.Show("Sửa ko thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Xin hãy nhập đầy đủ");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn thành viên muốn sửa");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dòng nào trong datagridview chưa
            Int32 selectedCellCount =
                            dtgvTK.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                string tdn = txtUser.Text.Trim();

                // Xóa
                if (busTK.xoaTaiKhoan(tdn))
                {
                    MessageBox.Show("Xóa thành công");
                    dtgvTK.DataSource = busTK.getTaiKhoan(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Xóa ko thành công");
                }
            }
        }

        private void frmQLTK_Load(object sender, EventArgs e)
        {
            dtgvTK.DataSource = busTK.getTaiKhoan();
        }

        private void dtgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvTK.CurrentCell.RowIndex;
            txtUser.Text = dtgvTK.Rows[i].Cells[0].Value.ToString();
            txtPass.Text = dtgvTK.Rows[i].Cells[1].Value.ToString();
            cbbQuyen.SelectedValue = dtgvTK.Rows[i].Cells[2].Value.ToString();
        }
    }
}
