﻿using System;
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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DanhSachKhachHang danhSachKhachHang = new DanhSachKhachHang();
            //danhSachKhachHang.ShowDialog();

            //DanhSachSanPham danhSachSanPham = new DanhSachSanPham();
            //danhSachSanPham.ShowDialog();

            //DanhSachNhanVien danhSachNhanVien = new DanhSachNhanVien();
            //danhSachNhanVien.ShowDialog();

            //HoaDonBan hoaDonBan = new HoaDonBan();
            //hoaDonBan.ShowDialog();

            //DanhSachHoaDonBan danhSachHoaDonBan = new DanhSachHoaDonBan();
            //danhSachHoaDonBan.ShowDialog();

            // Bài của Đức
            CaLam caLam = new CaLam();
            caLam.ShowDialog();
        }
    }
}