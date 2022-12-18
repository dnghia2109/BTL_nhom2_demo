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

        

        private void btnDanhSachSanPham_Click(object sender, EventArgs e)
        {
            DanhSachSanPham danhSachSanPham = new DanhSachSanPham();
            danhSachSanPham.ShowDialog();
        }

        private void btnDanhSachNhanVien_Click(object sender, EventArgs e)
        {
            DanhSachNhanVien danhSachNhanVien = new DanhSachNhanVien();
            danhSachNhanVien.ShowDialog();
        }

        private void btnDanhSachKhachHang_Click(object sender, EventArgs e)
        {
            DanhSachKhachHang danhSachKhachHang = new DanhSachKhachHang();
            danhSachKhachHang.ShowDialog();
        }

        private void btnDanhSachNcc_Click(object sender, EventArgs e)
        {
            QuanLyNCC quanLyNCC = new QuanLyNCC();
            quanLyNCC.ShowDialog();
        }

        private void btnDanhSachChatLieu_Click(object sender, EventArgs e)
        {
            ChatLieu chatLieu = new ChatLieu();
            chatLieu.ShowDialog();

        }

        private void btnDanhSachHoaDon_Click(object sender, EventArgs e)
        {
            DanhSachHoaDonBan danhSachHoaDon = new DanhSachHoaDonBan();
            danhSachHoaDon.ShowDialog();
        }

        private void btnHoaDonBan_Click(object sender, EventArgs e)
        {
            HoaDonBan hoaDonBan = new HoaDonBan();
            hoaDonBan.ShowDialog();
        }

        private void btnDanhSachCaLam_Click(object sender, EventArgs e)
        {
            CaLam caLam = new CaLam();
            caLam.ShowDialog();
        }

        private void btnLoaiSanPham_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
