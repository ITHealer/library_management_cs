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
    public partial class frmXemSach : Form
    {
        BUS_SACH busSach = new BUS_SACH();
        public frmXemSach()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text != "")
            {
                dtgvSach.DataSource = busSach.timKiem(txtTim.Text);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmXemSach_Load(object sender, EventArgs e)
        {
            dtgvSach.DataSource = busSach.getSach();       
        }
    }
}
