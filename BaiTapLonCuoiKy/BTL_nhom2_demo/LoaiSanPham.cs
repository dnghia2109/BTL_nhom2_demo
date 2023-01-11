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
    public partial class LoaiSanPham : Form
    {
        QLBH_nhom02Entities db = new QLBH_nhom02Entities();

        public LoaiSanPham()
        {
            InitializeComponent();
            LoadData();
        }

        public Boolean CheckEmptyInfo()
        {
           
            if (String.IsNullOrEmpty(txbTenLoai.Text))
            {
                MessageBox.Show("Vui lòng điền tên loại hàng.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txbTenLoai.Focus();
                return false;
            }

            return true;
        }

        public void LoadData()
        {

            var res = from c in db.tb_Loaihang 
                      select new { c.ma_loai, c.ten_loai };
            dataGridView1.DataSource = res.ToList();
            dataGridView1.Columns[0].HeaderText = "Mã loại";
            dataGridView1.Columns[1].HeaderText = "Tên loại hàng";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[0].Width = 100;
            txbTenLoai.Clear();
        }

        public void Create()
        {
            if (CheckEmptyInfo())
            {
                tb_Loaihang loaiHang = new tb_Loaihang()
                {
                    ten_loai = txbTenLoai.Text
                };
                db.tb_Loaihang.Add(loaiHang);
                db.SaveChanges();
                LoadData();
            }
        }

        public void Edit()
        {
            if (CheckEmptyInfo()) { 
                int maLoai = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ma_loai"].Value.ToString());
                tb_Loaihang curLoaiHang = db.tb_Loaihang.Where(c => c.ma_loai == maLoai).SingleOrDefault();
                curLoaiHang.ten_loai = txbTenLoai.Text;
                db.SaveChanges();
                LoadData();
            }
        }

        public void Delete()
        {
            int maLoai = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ma_loai"].Value.ToString());
            tb_Loaihang curLoaiHang = db.tb_Loaihang.Where(c => c.ma_loai == maLoai).SingleOrDefault();
            db.tb_Loaihang.Remove(curLoaiHang);
            db.SaveChanges();
            LoadData();
        }

        private void LoaiSanPham_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];
            txbTenLoai.Text = Convert.ToString(row.Cells["ten_loai"].Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Create();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
