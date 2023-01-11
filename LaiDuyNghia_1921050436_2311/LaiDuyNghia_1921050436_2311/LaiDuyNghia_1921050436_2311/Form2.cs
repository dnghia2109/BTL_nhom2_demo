using LaiDuyNghia_1921050436_2311.DTO;
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

namespace LaiDuyNghia_1921050436_2311
{
    public partial class Form2 : Form
    {
        private DataSet ds;
        private DataTable dt;
        QLTHUVIEN1Entities db = new QLTHUVIEN1Entities();

        public Form2()
        {
            InitializeComponent();
            LoadData();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadData()
        {
            //QLTHUVIEN1Entities db = new QLTHUVIEN1Entities();
            var res = from c in db.NHANVIENs               
                      select new { c.MaNhanVien, Tên = c.HoTenNhanVien, c.NgaySinh, c.DiaChi, SĐT = c.DienThoai, BangCap = c.BANGCAP.TenBangCap};
            dataGridView1.DataSource = res.ToList();

            //var rs2 = from c in db.BANGCAPs
            //          select c;
            //comboBox1.DataSource = rs2.ToList();
            //comboBox1.DisplayMember = "TenBangCap";
            //comboBox1.ValueMember = "MaBangCap";
            LoadBangCap();
        }

        public void LoadBangCap()
        {
            var rs2 = from c in db.BANGCAPs
                      select c;
            comboBox1.DataSource = rs2.ToList();
            comboBox1.DisplayMember = "TenBangCap";
            comboBox1.ValueMember = "MaBangCap";
        }

        public void Create()
        {
            NHANVIEN nhanVien = new NHANVIEN()
            {
                HoTenNhanVien = txbName.Text,
                NgaySinh = DateTime.Parse(dateTimePicker1.Text),
                DiaChi = txbDiaChi.Text,                                               
                DienThoai = txbDienThoai.Text,
                MaBangCap = int.Parse(comboBox1.SelectedValue.ToString())
            };
            db.NHANVIENs.Add(nhanVien);
            db.SaveChanges();         
            LoadData();
            clearContent();
        }

        public void Delete()
        {
            int manv = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["MaNhanVien"].Value.ToString());
            NHANVIEN curNV = db.NHANVIENs.Where(nv => nv.MaNhanVien == manv).SingleOrDefault();
            DialogResult res = MessageBox.Show("Do you want to delete ?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                db.NHANVIENs.Remove(curNV);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công", "Notification", MessageBoxButtons.OK);
                LoadData();
            } 
        }

        public void Edit()
        {
            int manv = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["MaNhanVien"].Value.ToString());
            NHANVIEN curNV = db.NHANVIENs.Where(nv => nv.MaNhanVien == manv).SingleOrDefault();
            
            curNV.HoTenNhanVien = txbName.Text;
            curNV.NgaySinh = DateTime.Parse(dateTimePicker1.Text);
            curNV.DiaChi = txbDiaChi.Text;
            curNV.DienThoai = txbDienThoai.Text;
            curNV.MaBangCap = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Cập nhật thành công", "Notification", MessageBoxButtons.OK);
            LoadData();
            clearContent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Create();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txbName.Text = row.Cells[1].Value.ToString();
            dateTimePicker1.Text = row.Cells[2].Value.ToString();
            txbDiaChi.Text = row.Cells[3].Value.ToString();
            txbDienThoai.Text = row.Cells[4].Value.ToString();
            comboBox1.DisplayMember = row.Cells[5].Value.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Close();
            }
        }

        public void clearContent()
        {
            txbName.Clear();
            txbDiaChi.Clear();
            txbDienThoai.Clear();
            LoadBangCap();
        }
    }
}
