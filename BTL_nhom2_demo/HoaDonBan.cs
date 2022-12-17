using BTL_nhom2_demo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom2_demo
{
    public partial class HoaDonBan : Form
    {
        QLBH_04Entities db = new QLBH_04Entities();

        public HoaDonBan()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       
             
        public void LoadComboMaNhanVien()
        {
            var rs = from c in db.tb_Nhanvien
                     select c;
            cbMaNhanVien.DataSource = rs.ToList();
            cbMaNhanVien.DisplayMember = "ten_nv";
            cbMaNhanVien.ValueMember = "ma_nv";
            cbMaHang.SelectedIndex = -1;
        }

        public void LoadComboKhachHang()
        {
            var rs = from c in db.tb_Khachhang select c;
            cbMaKH.DataSource = rs.ToList();
            cbMaKH.DisplayMember = "ten_kh";
            cbMaKH.ValueMember = "ma_kh";
            cbMaKH.SelectedIndex = -1;
        }

        public void LoadComboHangHoa()
        {
            var rs = from c in db.tb_Hanghoa select c;
            cbMaHang.DataSource = rs.ToList();
            cbMaHang.DisplayMember = "ten_hang";
            cbMaHang.ValueMember = "ma_hang";
            cbMaHang.SelectedIndex = -1;
        }


        private void HoaDonBan_Load(object sender, EventArgs e)
        {
            txbMaHoaDon.ReadOnly = true;
            txbTenNhanVien.ReadOnly = true;
            txbTongThanhTien.ReadOnly = true;
            txbDiaChi.ReadOnly = true;
            txbDienThoai.ReadOnly = true;
            txbDiaChi.ReadOnly = true;

            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            
            LoadComboMaNhanVien();
            LoadComboKhachHang();
            LoadComboHangHoa();
            if (txbMaHoaDon.Text != "")
            {
                LoadFormChiTietHoaDon();
                btnDelete.Enabled = true;
                //LoadDataGridViewChiTietHoaDon();
            }

            // Cần có mã hóa đơn mới load đc nếu như muốn xem chi tiết hóa đơn
            LoadDataGridViewChiTietHoaDon();
        }


        // Hiển thị dữ liệu cho chi tiết hóa đơn
        public void LoadDataGridViewChiTietHoaDon()
        {
            string maHoaDonBan = (txbMaHoaDon.Text);
            if (maHoaDonBan != null)
            {
                var result = from a in db.tb_CTHDB
                             join b in db.tb_Hanghoa on a.ma_hang equals b.ma_hang
                             where a.ma_hdb == maHoaDonBan
                             select new { a.ma_hang, b.ten_hang, a.so_luong, b.don_gia_ban, a.giam_gia, a.thanh_tien };

                // Sử dụng Linq method (src tham khảo: https://www.entityframeworktutorial.net/Querying-with-EDM.aspx) 
                //var rs2 = db.tb_CTHDB
                //    .Where(s => s.ma_hdb == maHoaDonBan)
                //    .Join(db.tb_Hanghoa, b => b.ma_hang, c => c.ma_nuoc, (b, c) => new
                //    {
                //        b.ma_hang, c.ten_hang, b.so_luong, c.don_gia_ban, b.giam_gia, b.thanh_tien
                //    }).ToList();

                dataGridView1.DataSource = result.ToList(); 
                dataGridView1.Columns[0].HeaderText = "Mã sản phẩm";
                dataGridView1.Columns[1].HeaderText = "Tên sản phẩm";
                dataGridView1.Columns[2].HeaderText = "Số lượng";
                dataGridView1.Columns[3].HeaderText = "Đơn giá";
                dataGridView1.Columns[4].HeaderText = "Khuyến mãi (%)";
                dataGridView1.Columns[5].HeaderText = "Thành tiền";
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 130;
                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[3].Width = 90;
                dataGridView1.Columns[4].Width = 90;
                dataGridView1.Columns[5].Width = 130;

                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.Columns[0].HeaderText = "Mã sản phẩm";
                dataGridView1.Columns[1].HeaderText = "Tên sản phẩm";
                dataGridView1.Columns[2].HeaderText = "Số lượng";
                dataGridView1.Columns[3].HeaderText = "Đơn giá";
                dataGridView1.Columns[4].HeaderText = "Khuyến mãi (%)";
                dataGridView1.Columns[5].HeaderText = "Thành tiền";
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 130;
                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[3].Width = 90;
                dataGridView1.Columns[4].Width = 90;
                dataGridView1.Columns[5].Width = 130;
            }
        }

        // Tải lên thông tin form chi tiết hóa đơn
        public void LoadFormChiTietHoaDon()
        {
            //int maHoaDonBan = Convert.ToInt32(txbMaHoaDon.Text);
            
            string maHoaDonBan = (txbMaHoaDon.Text);
            var rs = (from c in db.tb_HDB
                     where c.ma_hdb == maHoaDonBan
                     select c);

            foreach (var item in rs)
            {
                //dateTimePicker1.Text = item.ngay_ban.ToString();
                dateTimePicker1.Value = item.ngay_ban.Value;
                cbMaNhanVien.Text = item.ma_nv.ToString();
                cbMaKH.Text = item.ma_kh.ToString();
                txbTongThanhTien.Text = item.thanh_tien.ToString();
            }
        }

        // Xử lý "Thêm mới hóa đơn"
        private void btnAdd_Click(object sender, EventArgs e)
        {
                    
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;

            ResetValues();

            // Gen ra random mã hóa đơn
            Random random = new Random();
            int newMaHoaDon = random.Next(9999);
            
            // Check xem newMaHoaDon có trùng với mã hóa đơn cũ không
            var rs = from c in db.tb_HDB
                     select c;
            foreach(var item in rs)
            {
                while (item.ma_hdb == Convert.ToString(newMaHoaDon))
                {
                    newMaHoaDon++;
                }
            }
            txbMaHoaDon.Text = Convert.ToString(newMaHoaDon);

            LoadDataGridViewChiTietHoaDon();
        }

        // Trả về gtri mặc định ban đầu của các input
        public void ResetValues()
        {
            txbMaHoaDon.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            cbMaNhanVien.Text = "";
            cbMaKH.Text = "";
            txbTongThanhTien.Text = "0";
            cbMaHang.Text = "";
            txbSoLuong.Text = "";
            txbKhuyenMai.Text = "0";
        }


        // Xử lý "Lưu hóa đơn"
        private void btnSave_Click(object sender, EventArgs e)
        {
            double soLuong, soLuongConlai, tongThanhTienCu, tongThanhTienMoi;           
            string maHoaDonBan = (txbMaHoaDon.Text);

            //Check xem đã tồn tại hóa đơn chưa. Nếu chưa thì lưu maHD mới vào db.tb_HDB trước
            var rs1 = from c in db.tb_HDB
                      where c.ma_hdb == maHoaDonBan
                      select c.ma_hdb;
            if (!(rs1.Count() > 0))
            {
                if (cbMaNhanVien.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaNhanVien.Focus();
                    return;
                }
                if (cbMaKH.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaKH.Focus();
                    return;
                }

                tb_HDB newHDB = new tb_HDB()
                {
                    ma_hdb = maHoaDonBan,
                    ngay_ban = dateTimePicker1.Value,
                    ma_nv = Convert.ToInt32(cbMaNhanVien.SelectedValue.ToString()),
                    ma_kh = Convert.ToInt32(cbMaKH.SelectedValue.ToString()),
                    thanh_tien = Convert.ToDouble(txbTongThanhTien.Text),
                };
                db.tb_HDB.Add(newHDB);
                db.SaveChanges();
            }


            // Tiến hành lưu thông tin mặt hàng của hóa đơn
            if (cbMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaHang.Focus();
                return;
            }

            if ((txbSoLuong.Text.Trim().Length == 0) || (txbSoLuong.Text == "0"))
            {
                MessageBox.Show("Vui lòng nhập số lượng sản phẩm lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSoLuong.Text = "";
                txbSoLuong.Focus();
                return;
            }

            if (txbKhuyenMai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbKhuyenMai.Focus();
                return;
            }

            // Ktra xem sản phẩm nhập mới đã có trong ds sp chưa
            int maHangSelected = Convert.ToInt32(cbMaHang.SelectedValue);
            var rs = from c in db.tb_CTHDB
                     where c.ma_hang == maHangSelected  && c.ma_hdb == maHoaDonBan
                     select c.ma_hang;
            if (rs.Count() > 0)
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cbMaHang.Focus();
                return;
            }
            
            // Ktra số lượng còn lại trong kho
            tb_Hanghoa curSanPham = db.tb_Hanghoa.Where(sp => sp.ma_hang == maHangSelected).SingleOrDefault();
            soLuong = (double)curSanPham.so_luong;
            if (Convert.ToDouble(txbSoLuong.Text) > soLuong )
            {
                MessageBox.Show("Số lượng của sản phẩm này chỉ còn " + soLuong, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSoLuong.Text = "";
                txbSoLuong.Focus();
                return;
            }
            

            db.tb_CTHDB.Add(new tb_CTHDB()
            {
                ma_hdb = maHoaDonBan,
                ma_hang = curSanPham.ma_hang,
                so_luong = Convert.ToDouble(txbSoLuong.Text),
                don_gia = curSanPham.don_gia_ban,
                giam_gia = Convert.ToDouble(txbKhuyenMai.Text),
                thanh_tien = curSanPham.don_gia_ban*Convert.ToDouble(txbSoLuong.Text)-(curSanPham.don_gia_ban*Convert.ToDouble(txbSoLuong.Text)*(Convert.ToDouble(txbKhuyenMai.Text)/100)),
            });
            db.SaveChanges();
            LoadDataGridViewChiTietHoaDon();

            // Cập nhật số lượng sản phẩm cho bảng tb_Hanghoa
            soLuongConlai = soLuong - Convert.ToDouble(txbSoLuong.Text);
            curSanPham.so_luong = soLuongConlai;
            db.SaveChanges();

            // Cập nhật lại tổng tiền cho hóa đơn bán
            tb_HDB curHoaDonBan = db.tb_HDB.Where(hoaDon => hoaDon.ma_hdb == maHoaDonBan).SingleOrDefault();
            tongThanhTienCu = (double)curHoaDonBan.thanh_tien;  
            tongThanhTienMoi = (double)((double)tongThanhTienCu + (curSanPham.don_gia_ban*Convert.ToDouble(txbSoLuong.Text)-
                (curSanPham.don_gia_ban*Convert.ToDouble(txbSoLuong.Text)*(Convert.ToDouble(txbKhuyenMai.Text)/100))));
            curHoaDonBan.thanh_tien = tongThanhTienMoi;  
            
            db.SaveChanges();

            txbTongThanhTien.Text = tongThanhTienMoi.ToString(); 
            ResetValuesHang();
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
        }

        // Reset lại khi mặt hàng thêm mới đã có trên gridview sản phẩm
        private void ResetValuesHang()
        {
            cbMaHang.Text = "";
            txbSoLuong.Text = "";
            txbKhuyenMai.Text = "0";
        }


        // Xử lý "Xóa hóa đơn"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string maHoaDonBan = (txbMaHoaDon.Text);
            string maHoaDonBan2 = (txbMaHoaDon.Text);
            double sl, slcon, slxoa;
            DialogResult res = MessageBox.Show("Bạn có muốn xóa hóa đơn này?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            { 
                var rs = from c in db.tb_CTHDB
                         where c.ma_hdb == maHoaDonBan2
                         select c;

                //for (int i = 0; rs.ToList() ; i++)
                foreach (var item in rs)
                {

                    // Cập nhật lại số lượng sau khi xóa hóa đơn             
                    tb_Hanghoa sanPham = db.tb_Hanghoa.Where(c => c.ma_hang == item.ma_hang).FirstOrDefault();
                    sl = (double)sanPham.so_luong;
                    slxoa = (double)item.so_luong;
                    slcon = sl + slxoa;
                    sanPham.so_luong = slcon;
                    //db.SaveChanges();
                }

                // Xóa ChiTietHoaDon khỏi tb_CTHDB
                tb_CTHDB CTHDB = db.tb_CTHDB.Where(c => c.ma_hdb == maHoaDonBan).SingleOrDefault();
                db.tb_CTHDB.Remove(CTHDB);
                //db.SaveChanges();

                // Xóa HoaDonBan khỏi tb_HDB
                tb_HDB HDB = db.tb_HDB.Where(c => c.ma_hdb == maHoaDonBan).SingleOrDefault();
                db.tb_HDB.Remove(HDB);
                db.SaveChanges();

                ResetValues();
                LoadDataGridViewChiTietHoaDon();
                btnDelete.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cbMaHD_DropDown(object sender, EventArgs e)
        {
            var rs = from c in db.tb_HDB
                     select c;
            cbMaHD.DataSource = rs.ToList();
            cbMaHD.DisplayMember = "ma_hdb";
            cbMaHD.ValueMember = "ma_hdb";
            cbMaHD.SelectedIndex = -1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbMaHD.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaHD.Focus();
                return;
            }
            txbMaHoaDon.Text = cbMaHD.Text;
            LoadFormChiTietHoaDon();
            LoadDataGridViewChiTietHoaDon(); 
            btnDelete.Enabled = true;
            btnSave.Enabled = true;           
            cbMaHD.SelectedIndex = -1;
        }


        // Double click để xóa 1 sản phẩm khỏi danh sách chi tiết đơn hàng
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string maHoaDonBan = (txbMaHoaDon.Text);
            DialogResult res = MessageBox.Show("Bạn có muốn xóa sản phẩm này khỏi hóa đơn?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                int maSanPhamXoa = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ma_hang"].Value.ToString());
                
                double soLuongSPXoa = Convert.ToDouble(dataGridView1.CurrentRow.Cells["so_luong"].Value.ToString());
                
                double thanhTienSanPhamXoa = Convert.ToDouble(dataGridView1.CurrentRow.Cells["thanh_tien"].Value.ToString());

                tb_CTHDB curCTHDB = db.tb_CTHDB.Where(c => c.ma_hdb == maHoaDonBan && c.ma_hang == maSanPhamXoa).SingleOrDefault();

                // update lại số lượng sản cho bảng tb_Hanghoa
                tb_Hanghoa curSanPham = db.tb_Hanghoa.Where(c => c.ma_hang == maSanPhamXoa).SingleOrDefault();
                double soLuongConLai = (double)curSanPham.so_luong;
                double soLuongMoi = soLuongConLai + soLuongSPXoa;
                curSanPham.so_luong = soLuongMoi;

                // update lại tổng thành tiền cho tb_HDB
                tb_HDB curHDB = db.tb_HDB.Where(c => c.ma_hdb == maHoaDonBan).SingleOrDefault();
                double tongThanhTienBanDau = (double)curHDB.thanh_tien;
                double tongThanhTienMoi = tongThanhTienBanDau - thanhTienSanPhamXoa;
                curHDB.thanh_tien = tongThanhTienMoi;

                db.tb_CTHDB.Remove(curCTHDB);
                db.SaveChanges();

                txbTongThanhTien.Text = tongThanhTienMoi.ToString();
                LoadDataGridViewChiTietHoaDon();

            }
        }
    }
}
