using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom2_demo
{
    public partial class DanhSachHoaDonBan : Form
    {
        public DanhSachHoaDonBan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mahd = textBox1.Text;
            HoaDonBan hoaDonBan = new HoaDonBan();
            hoaDonBan.txbMaHoaDon.Text = mahd;
            hoaDonBan.StartPosition = FormStartPosition.CenterParent;
            hoaDonBan.ShowDialog();
        }
    }
}
