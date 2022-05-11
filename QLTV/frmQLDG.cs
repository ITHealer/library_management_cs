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
using System.Data.SqlClient;
namespace QLTV
{
    public partial class frmQLDG : Form
    {
        BUS_DOCGIA busDG = new BUS_DOCGIA();
        BUS_MUONSACH busMS = new BUS_MUONSACH();
        public frmQLDG()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // load dữ liệu lên datagridview
        private void frmQLDG_Load(object sender, EventArgs e)
        {
            dtgvDG.DataSource = busDG.getDocGia();
        }

        // click vào một dòng trong datagridview dữ liệu sẽ được map lên trên các ô
        private void dtgvDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvDG.CurrentCell.RowIndex;
            txtMaDG.Text = dtgvDG.Rows[i].Cells[0].Value.ToString();
            txtHoTen.Text = dtgvDG.Rows[i].Cells[1].Value.ToString();
            string gt = dtgvDG.Rows[i].Cells[2].Value.ToString();
            if (gt == "True")
                rbNam.Checked = true;
            else
                rbNu.Checked = true;
            dtpNgaySinh.Text = dtgvDG.Rows[i].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text != "")
            {
                bool gt;
                if (rbNam.Checked)
                {
                    gt = true;
                }
                else
                {
                    gt = false;
                }

                // Tạo DTO
                DTO_DocGia tv = new DTO_DocGia(txtMaDG.Text, txtHoTen.Text, gt, dtpNgaySinh.Value); // Vì ID tự tăng nên để ID số gì cũng dc
                // Thêm
                if (busDG.themDocGia(tv))
                {
                    MessageBox.Show("Thêm thành công");
                    dtgvDG.DataSource = busDG.getDocGia(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
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
            Int32 selectedCellCount =
                            dtgvDG.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                if (txtMaDG.Text != "" && txtHoTen.Text != "")
                {
                    bool gt;
                    if (rbNam.Checked)
                    {
                        gt = true;
                    }
                    else
                    {
                        gt = false;
                    }
                    // Tạo DTO
                    DTO_DocGia tv = new DTO_DocGia(txtMaDG.Text, txtHoTen.Text, gt, dtpNgaySinh.Value);

                    // Sửa
                    if (busDG.suaDocGia(tv))
                    {
                        MessageBox.Show("Sửa thành công");
                        dtgvDG.DataSource = busDG.getDocGia(); // refresh datagridview
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
                            dtgvDG.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                string tdn = txtMaDG.Text.Trim();
                if (busMS.xoaMuonSach2(tdn))
                {
                    if (busDG.xoaDocGia(tdn))
                    {
                        MessageBox.Show("Xóa thành công");
                        dtgvDG.DataSource = busDG.getDocGia(); // refresh datagridview
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
    }
}
