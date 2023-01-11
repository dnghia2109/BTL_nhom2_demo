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
    public partial class Form3 : Form
    {
        QLTHUVIEN1Entities db = new QLTHUVIEN1Entities();

        public Form3()
        {
            InitializeComponent();
            LoadData();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            var res = from c in db.SACHes
                      select new { c.MaSach, Tên = c.TenSach, c.TacGia, c.NamXuatBan, c.NhaXuatBan, c.TriGia, c.NgayNhap };
            dataGridView1.DataSource = res.ToList();
        }

        public void Create()
        {
            SACH sach = new SACH()
            {
                TenSach = txbName.Text,
                NgayNhap = DateTime.Parse(dateTimePicker1.Text),
                TacGia = txbTacGia.Text,
                NamXuatBan = int.Parse(txbNamXuatban.Text),
                TriGia  = int.Parse(txbTriGia.Text),               
            };
            db.SACHes.Add(sach);
            db.SaveChanges();
            LoadData();
            clearContent();
        }

        public void Delete()
        {
            int maSach = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["MaSach"].Value.ToString());
            SACH curSach = db.SACHes.Where(sach => sach.MaSach == maSach).SingleOrDefault();
            DialogResult res = MessageBox.Show("Do you want to delete ?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                db.SACHes.Remove(curSach);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công", "Notification", MessageBoxButtons.OK);
                LoadData();
            }
        }

        public void Edit()
        {
            int maSach = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["MaSach"].Value.ToString());
            SACH curSach = db.SACHes.Where(sach => sach.MaSach == maSach).SingleOrDefault();

            curSach.TenSach = txbName.Text;
            curSach.NgayNhap = DateTime.Parse(dateTimePicker1.Text);
            curSach.TacGia = txbTacGia.Text;
            curSach.NamXuatBan =  int.Parse(txbNamXuatban.Text);
            curSach.TriGia  = int.Parse(txbTriGia.Text);
            db.SaveChanges();
            MessageBox.Show("Cập nhật thành công", "Notification", MessageBoxButtons.OK);
            LoadData();
            clearContent();
            
        }

        public void clearContent()
        {
            txbName.Clear();
            txbTacGia.Clear();
            txbNamXuatban.Clear();
            txbNhaXuatBan.Clear();
            //dateTimePicker1.;
            txbTriGia.Clear();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txbName.Text = row.Cells[1].Value.ToString();
            txbTacGia.Text = row.Cells[2].Value.ToString();
            txbNamXuatban.Text = row.Cells[3].Value.ToString();
            txbNhaXuatBan.Text = row.Cells[4].Value.ToString();
            txbTriGia.Text = row.Cells[5].Value.ToString();
            dateTimePicker1.Text = row.Cells[6].Value.ToString();
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
            DialogResult res = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
