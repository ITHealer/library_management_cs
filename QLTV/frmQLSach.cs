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
    public partial class frmQLSach : Form
    {
        BUS_SACH busSach = new BUS_SACH();
        BUS_MUONSACH busMS = new BUS_MUONSACH();
        public frmQLSach()
        {
            InitializeComponent();
        }

        private void frmQLSach_Load(object sender, EventArgs e)
        {
            dtgvSach.DataSource = busSach.getSach();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text != "")
            {
                dtgvSach.DataSource = busSach.timKiem(txtTim.Text);
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (txtMaSach.Text != "" && txtTenSach.Text != "" && txtNXB.Text != "")
            {
                // Tạo DTO
                DTO_Sach s = new DTO_Sach(txtMaSach.Text, txtTenSach.Text, txtNXB.Text); // Vì ID tự tăng nên để ID số gì cũng dc

                // Thêm
                if (busSach.themSach(s))
                {
                    MessageBox.Show("Thêm thành công");
                    dtgvSach.DataSource = busSach.getSach(); // refresh datagridview
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

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dòng nào trong datagridview chưa
            //https://docs.microsoft.com/vi-vn/dotnet/desktop/winforms/controls/selected-cells-rows-and-columns-datagridview?view=netframeworkdesktop-4.8
            Int32 selectedCellCount =
                            dtgvSach.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                if (txtMaSach.Text != "" && txtTenSach.Text != "" && txtNXB.Text != "")
                {
                    // Tạo DTO
                    DTO_Sach s = new DTO_Sach(txtMaSach.Text, txtTenSach.Text, txtNXB.Text);

                    // Sửa
                    if (busSach.suaSach(s))
                    {
                        MessageBox.Show("Sửa thành công");
                        dtgvSach.DataSource = busSach.getSach(); // refresh datagridview
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

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dòng nào trong datagridview chưa
            Int32 selectedCellCount =
                            dtgvSach.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                string tdn = txtMaSach.Text.Trim();
                if (busMS.xoaMuonSach3(tdn))
                {
                    if (busSach.xoaSach(tdn))
                    {
                        MessageBox.Show("Xóa thành công");
                        dtgvSach.DataSource = busSach.getSach(); // refresh datagridview
                    }
                    else
                    {
                        MessageBox.Show("Xóa ko thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgvSach_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvSach.CurrentCell.RowIndex;
            txtMaSach.Text = dtgvSach.Rows[i].Cells[0].Value.ToString();
            txtTenSach.Text = dtgvSach.Rows[i].Cells[1].Value.ToString();
            txtNXB.Text = dtgvSach.Rows[i].Cells[2].Value.ToString();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            dtgvSach.DataSource = busSach.getSach();
        }
    }
}
