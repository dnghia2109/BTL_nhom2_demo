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

namespace LaiDuyNghia_1921050436_2311
{
    public partial class Form4 : Form
    {
        QLTHUVIEN1Entities db = new QLTHUVIEN1Entities();

        public Form4()
        {
            InitializeComponent();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadData()
        {
            var res = from c in db.DOCGIAs
                      select new { c.MaDocGia, Tên = c.HoTenDocGia, c.NgaySinh, c.DiaChi, c.Email, c.NgayLapThe, c.NgayHetHan, c.TienNo };
            dataGridView1.DataSource = res.ToList();
        }

        public void clearContent()
        {
            txbName.Clear();
            txbDiaChi.Clear();
            txbEmail.Clear();
            txbTienNo.Clear();
        }

        public void Create()
        {
            DOCGIA docGia = new DOCGIA()
            {
                HoTenDocGia = txbName.Text,
                NgaySinh = DateTime.Parse(dateTimePicker1.Text),
                DiaChi = txbDiaChi.Text,
                Email = txbEmail.Text,
                NgayLapThe = DateTime.Parse(dateTimePicker2.Text),
                NgayHetHan = DateTime.Parse(dateTimePicker3.Text),
                TienNo = int.Parse(txbTienNo.Text)
            };
            db.DOCGIAs.Add(docGia);
            db.SaveChanges();
            LoadData();
            clearContent();
        }

        public void Delete()
        {
            int maDocGia = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["MaDocGia"].Value.ToString());
            DOCGIA curDocGia = db.DOCGIAs.Where(docGia => docGia.MaDocGia == maDocGia).SingleOrDefault();
            DialogResult res = MessageBox.Show("Do you want to delete ?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                db.DOCGIAs.Remove(curDocGia);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công", "Notification", MessageBoxButtons.OK);
                LoadData();
            }
        }

        public void Edit()
        {
            int maDocGia = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["MaDocGia"].Value.ToString());
            DOCGIA curDocGia = db.DOCGIAs.Where(docGia => docGia.MaDocGia == maDocGia).SingleOrDefault();
            curDocGia.HoTenDocGia = txbName.Text;
            curDocGia.NgaySinh = DateTime.Parse(dateTimePicker1.Text);
            curDocGia.DiaChi = txbDiaChi.Text;
            curDocGia.Email = txbEmail.Text;
            curDocGia.NgayLapThe = DateTime.Parse(dateTimePicker2.Text);
            curDocGia.NgayHetHan = DateTime.Parse(dateTimePicker3.Text);
            curDocGia.TienNo = int.Parse(txbTienNo.Text);
            db.SaveChanges();
            MessageBox.Show("Cập nhật thành công", "Notification", MessageBoxButtons.OK);
            LoadData();
            clearContent();
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txbName.Text = row.Cells[1].Value.ToString();
            dateTimePicker1.Text = row.Cells[2].Value.ToString();
            txbDiaChi.Text = row.Cells[3].Value.ToString();
            txbEmail.Text = row.Cells[4].Value.ToString();
            dateTimePicker2.Text = row.Cells[5].Value.ToString();
            dateTimePicker3.Text = row.Cells[6].Value.ToString();
            txbTienNo.Text = row.Cells[7].Value.ToString();
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
