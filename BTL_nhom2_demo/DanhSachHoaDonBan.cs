using BTL_nhom2_demo.DTO;
using System;
using System.CodeDom;
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
    public partial class DanhSachHoaDonBan : Form
    {
        QLBH_nhom02Entities db = new QLBH_nhom02Entities();

        public DanhSachHoaDonBan()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            var rs = from c in db.tb_HDB
                     select new { c.ma_hdb, c.ma_nv, c.ma_kh, c.ngay_ban, c.thanh_tien };
            dataGridView1.DataSource = rs.ToList();
            LoadDataGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string mahd = txbMaHoaDonTimKiem.Text;
            if (mahd == "")
            {
                MessageBox.Show("Nhập mã hóa đơn muốn tìm kiếm", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rs = from c in db.tb_HDB
                     where c.ma_hdb.Contains(mahd)
                     select new { c.ma_hdb, c.ma_nv, c.ma_kh, c.ngay_ban, c.thanh_tien };
            dataGridView1.DataSource = rs.ToList();
            LoadDataGridView();

            //HoaDonBan hoaDonBan = new HoaDonBan();
            //hoaDonBan.txbMaHoaDon.Text = mahd;
            //hoaDonBan.StartPosition = FormStartPosition.CenterParent;
            //hoaDonBan.Show();
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

        private void DanhSachHoaDonBan_Load(object sender, EventArgs e)
        {
            
        }

        

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mahd = dataGridView1.CurrentRow.Cells["ma_hdb"].Value.ToString();
                HoaDonBan hoaDonBan = new HoaDonBan();
                hoaDonBan.txbMaHoaDon.Text = mahd;
                hoaDonBan.StartPosition = FormStartPosition.CenterParent;
                hoaDonBan.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
