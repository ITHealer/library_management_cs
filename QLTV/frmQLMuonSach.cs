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
    public partial class frmQLMuonSach : Form
    {
        BUS_MUONSACH busSach = new BUS_MUONSACH();
        public frmQLMuonSach()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQLMuonSach_Load(object sender, EventArgs e)
        {
            dtgvMuonSach.DataSource =  busSach.getMuonSach2();
        }

        private void dtgvMuonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvMuonSach.CurrentCell.RowIndex;
            txtMaSach.Text = dtgvMuonSach.Rows[i].Cells[0].Value.ToString();
            txtDG.Text = dtgvMuonSach.Rows[i].Cells[2].Value.ToString();
            dtpNgayMuon.Text = dtgvMuonSach.Rows[i].Cells[4].Value.ToString();
            dtpNgayTra.Text = dtgvMuonSach.Rows[i].Cells[5].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text != "" && txtDG.Text != "" && dtpNgayMuon.Text != "" && dtpNgayTra.Text != "")
            {
                // Tạo DTO
                DTO_MuonSach s = new DTO_MuonSach(txtMaSach.Text, txtDG.Text, dtpNgayMuon.Value, dtpNgayTra.Value); // Vì ID tự tăng nên để ID số gì cũng dc

                // Thêm
                if (busSach.themMuonSach(s))
                {
                    MessageBox.Show("Thêm thành công");
                    dtgvMuonSach.DataSource = busSach.getMuonSach2(); // refresh datagridview
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
            Int32 selectedCellCount =
                            dtgvMuonSach.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                // Tạo DTO
                DTO_MuonSach tv = new DTO_MuonSach(txtMaSach.Text, txtDG.Text, dtpNgayMuon.Value, dtpNgayTra.Value);

                // Sửa
                if (busSach.suaMuonSach(tv))
                {
                    MessageBox.Show("Sửa thành công");
                    dtgvMuonSach.DataSource = busSach.getMuonSach2(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Sửa ko thành công");
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
                            dtgvMuonSach.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                string tdn = txtMaSach.Text.Trim();
                string tdn2 = txtDG.Text.Trim();
                
                // Xóa
                if (busSach.xoaMuonSach(tdn, tdn2))
                {
                    MessageBox.Show("Xóa thành công");
                    dtgvMuonSach.DataSource = busSach.getMuonSach2(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Xóa ko thành công");
                }
            }
        }

        // thống kê danh sách các độc giả quá hạn + tiền phạt
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            dtgvMuonSach.DataSource = busSach.getMuonSachQuaHan();
        }
    }
}
