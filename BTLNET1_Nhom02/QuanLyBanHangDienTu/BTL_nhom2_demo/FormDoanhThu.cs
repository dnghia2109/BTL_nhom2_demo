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

namespace BTL_nhom2_demo
{
    public partial class FormDoanhThu : Form
    {
        QLBH_nhom02Entities db = new QLBH_nhom02Entities();

        public FormDoanhThu()
        {
            InitializeComponent();
            LoadData();
        }

        private void FormDoanhThu_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            var rs = from c in db.tb_HDB
                     select new { c.ma_hdb, c.ma_nv, c.ma_kh, c.ngay_ban, c.thanh_tien };
            dataGridView1.DataSource = rs.ToList();

            double doanhThu = 0;
            foreach (var item in rs)
            {
                doanhThu += (double)item.thanh_tien;
            }
            LoadDataGridView();
            textBox1.ReadOnly = true;
            textBox1.Text = doanhThu.ToString();
        }

        public void LoadDataGridView()
        {
            dataGridView1.Columns[0].HeaderText = "Mã HĐB";
            dataGridView1.Columns[1].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[2].HeaderText = "Mã khách";
            dataGridView1.Columns[3].HeaderText = "Ngày bán";
            dataGridView1.Columns[4].HeaderText = "Thành tiền";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 80;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            double doanhThu = 0;
            var rs = from c in db.tb_HDB
                     where ((c.ngay_ban > dateTimePicker1.Value) && (c.ngay_ban < dateTimePicker2.Value))
                     select new { c.ma_hdb, c.ma_nv, c.ma_kh, c.ngay_ban, c.thanh_tien };

            foreach(var item in rs)
            {
                doanhThu += (double)item.thanh_tien;
            }
            dataGridView1.DataSource = rs.ToList();
            LoadDataGridView();

            textBox1.Text = doanhThu.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
