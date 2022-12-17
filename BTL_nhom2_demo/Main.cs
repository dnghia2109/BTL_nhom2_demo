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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachNhanVien danhSachNhanVien = new DanhSachNhanVien();
            danhSachNhanVien.ShowDialog();
            
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachKhachHang danhSachKhachHang = new DanhSachKhachHang();
            danhSachKhachHang.ShowDialog();
            
              
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachSanPham danhSachSanPham = new DanhSachSanPham();
            danhSachSanPham.ShowDialog();
            
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonBan hoaDonBan = new HoaDonBan();
            hoaDonBan.ShowDialog();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.ShowDialog();
            this.Close();   
        }
    }
}
