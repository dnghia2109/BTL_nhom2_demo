using BTL_nhom2_demo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL_nhom2_demo
{
    public partial class DanhSachSanPham : Form
    {
        QLBH_04Entities db = new QLBH_04Entities();

        public DanhSachSanPham()
        {
            InitializeComponent();
            LoadData();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DanhSachSanPham_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            var result = from c in db.tb_Hanghoa 
                         select new { c.ma_hang, c.ten_hang, c.tb_Loaihang.ten_loai, c.tb_Xuatxu.ten_nuoc, c.so_luong, c.tb_Chatlieu.ten_chat_lieu, c.don_gia_nhap, c.don_gia_ban, c.thoi_gian_bh };

            dataGridView1.DataSource = result.ToList();
            dataGridView1.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridView1.Columns[2].HeaderText = "Loại";
            dataGridView1.Columns[3].HeaderText = "Xuất xứ";
            dataGridView1.Columns[4].HeaderText = "Số lượng";
            dataGridView1.Columns[5].HeaderText = "Chất liệu";
            dataGridView1.Columns[6].HeaderText = "Giá nhập";
            dataGridView1.Columns[7].HeaderText = "Giá bán";
            dataGridView1.Columns[8].HeaderText = "Hạn bảo hành";

            LoadLoaiHang();
            LoadXuatXu();
            LoadChatLieu();
        }

        public void LoadChatLieu()
        {
            var rs = from c in db.tb_Chatlieu
                     select c;
            cbChatlieu.DataSource = rs.ToList();
            cbChatlieu.DisplayMember = "ten_chat_lieu";
            cbChatlieu.ValueMember = "ma_chat_lieu";
            cbChatlieu.SelectedIndex = -1;
            cbChatlieu.Text = "";
        }

        public void LoadLoaiHang()
        {
            var rs = from c in db.tb_Loaihang
                      select c;
            cbLoaiHang.DataSource = rs.ToList();
            cbLoaiHang.DisplayMember = "ten_loai";
            cbLoaiHang.ValueMember = "ma_loai";
            cbLoaiHang.SelectedIndex = -1;
            cbLoaiHang.Text = "";
        }

        public void LoadXuatXu()
        {
            var rs = from c in db.tb_Xuatxu
                     select c;
            cbXuatXu.DataSource = rs.ToList();
            cbXuatXu.DisplayMember = "ten_nuoc";
            cbXuatXu.ValueMember = "ma_nuoc";
            cbXuatXu.SelectedIndex = -1;
            cbXuatXu.Text = "";
        }

        public void ClearForm()
        {
            txbTen.Clear();
            LoadLoaiHang();
            txbSoLuong.Clear();
            txbGiaNhap.Clear();
            txbGiaBan.Clear();
            LoadXuatXu();
            txbBaoHanh.Clear();
        }

        public Boolean CheckEmptyInfo()
        {
            if (String.IsNullOrEmpty(txbTen.Text))
            {
                MessageBox.Show("Vui lòng điền tên sản phẩm", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txbTen.Focus();
                return false;
            }

            

            if (String.IsNullOrEmpty(cbLoaiHang.Text))
            {
                MessageBox.Show("Vui lòng chọn loại hàng", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cbLoaiHang.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(cbXuatXu.Text))
            {
                MessageBox.Show("Vui lòng chọn xuất xứ", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cbXuatXu.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txbSoLuong.Text) || float.Parse(txbSoLuong.Text) < 0)
            {
                MessageBox.Show("Vui lòng điền số lượng sản phẩm lớn hơn 0", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txbTen.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(cbChatlieu.Text))
            {
                MessageBox.Show("Vui lòng chọn chất liệu", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cbChatlieu.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txbGiaNhap.Text))
            {
                MessageBox.Show("Vui lòng điền Giá nhập", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txbGiaNhap.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txbGiaBan.Text))
            {
                MessageBox.Show("Vui lòng điền Giá bán", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txbGiaBan.Focus();
                return false;
            }

            if (float.Parse(txbGiaBan.Text) < float.Parse(txbGiaNhap.Text))
            {
                MessageBox.Show("Vui lòng điền Giá bán lớn hơn Giá nhập", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txbGiaBan.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txbBaoHanh.Text))
            {
                MessageBox.Show("Vui lòng điền thời gian bảo hành", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txbBaoHanh.Focus();
                return false;
            }

            return true;

        }

        public void Them()
        {
            //CheckEmptyInfo();
            if (CheckEmptyInfo())
            {
                tb_Hanghoa hangHoa = new tb_Hanghoa()
                {
                    ten_hang = txbTen.Text,
                    ma_loai = Convert.ToInt32(cbLoaiHang.SelectedValue.ToString()),
                    ma_nuoc = Convert.ToInt32(cbXuatXu.SelectedValue.ToString()),
                    so_luong = float.Parse(txbSoLuong.Text),
                    ma_chat_lieu = Convert.ToInt32(cbChatlieu.SelectedValue.ToString()),
                    don_gia_nhap = float.Parse(txbGiaNhap.Text),
                    don_gia_ban = float.Parse(txbGiaBan.Text),
                    thoi_gian_bh = txbBaoHanh.Text
                };

                db.tb_Hanghoa.Add(hangHoa);
                db.SaveChanges();
                LoadData();
                ClearForm();
            }
            
        }

        public void Sua()
        {
            if (CheckEmptyInfo())
            {
                int masp = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ma_hang"].Value.ToString());
                tb_Hanghoa curSanPham = db.tb_Hanghoa.Where(sp => sp.ma_hang == masp).SingleOrDefault();
                curSanPham.ten_hang = txbTen.Text;
                curSanPham.ma_loai = Convert.ToInt32(cbLoaiHang.SelectedValue.ToString());
                curSanPham.ma_nuoc = Convert.ToInt32(cbXuatXu.SelectedValue.ToString());
                curSanPham.so_luong = float.Parse(txbSoLuong.Text);
                curSanPham.ma_chat_lieu = Convert.ToInt32(cbChatlieu.SelectedValue.ToString());
                curSanPham.don_gia_nhap = float.Parse(txbGiaNhap.Text);
                curSanPham.don_gia_ban = float.Parse(txbGiaBan.Text);
                curSanPham.thoi_gian_bh = txbBaoHanh.Text;
                db.SaveChanges();
                LoadData();
                ClearForm();
            }
            
        }

        public void Xoa()
        {
            int masp = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ma_hang"].Value.ToString());
            tb_Hanghoa curSanPham = db.tb_Hanghoa.Where(sp => sp.ma_hang == masp).SingleOrDefault();

            DialogResult res = MessageBox.Show("Bạn có muốn xóa sản phẩm khỏi danh sách?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                db.tb_Hanghoa.Remove(curSanPham);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công", "Notification", MessageBoxButtons.OK);
                LoadData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Sua();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Xoa();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Close();
                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txbTen.Text = row.Cells[1].Value.ToString();
            cbLoaiHang.Text = row.Cells[2].Value.ToString();
            cbXuatXu.Text = row.Cells[3].Value.ToString();
            txbSoLuong.Text = row.Cells[4].Value.ToString();
            cbChatlieu.Text = row.Cells[5].Value.ToString();
            txbGiaNhap.Text = row.Cells[6].Value.ToString();
            txbGiaBan.Text = row.Cells[7].Value.ToString();
            txbBaoHanh.Text = row.Cells[8].Value.ToString();
        }

        //c.ten_hang, c.tb_Loaihang.ten_loai, c.tb_Xuatxu.ten_nuoc, c.so_luong, c.tb_Chatlieu.ten_chat_lieu,
        //c.don_gia_nhap, c.don_gia_ban, c.thoi_gian_bh 
    }
}
