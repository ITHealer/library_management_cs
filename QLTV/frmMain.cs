using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void qLTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLTK f = new frmQLTK();
            f.ShowDialog();
        }

        private void qLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLDG f = new frmQLDG();
            f.ShowDialog();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLSach f = new frmQLSach();
            f.ShowDialog();
        }

        private void mượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLMuonSach f = new frmQLMuonSach();
            f.ShowDialog();
        }
    }
}
