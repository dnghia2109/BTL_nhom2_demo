﻿using BTL_nhom2_demo.DTO;
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
    public partial class QuanLyNCC : Form
    {
        

        private void QuanLyNCC_Load(object sender, EventArgs e)
        {

        }

        QLBH_nhom02Entities db = new QLBH_nhom02Entities();

        public QuanLyNCC()
        {
            InitializeComponent();
            LoadData();
        }

        public Boolean CheckEmptyInfo()
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Vui lòng điền Tên NCC.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox2.Focus();
                return false;
            }

            if(String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Vui lòng điền địa chỉ.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox3.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Vui lòng điền SĐT.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBox4.Focus();
                return false;
            }

            return true;
        }

        public void LoadData()
        {
            
            var res = from c in db.tb_NCC select new {c.ma_ncc, c.ten_ncc, c.dia_chi, c.dien_thoai} ;
            dataGridView1.DataSource = res.ToList();
            dataGridView1.Columns[0].HeaderText = "Mã nhà cung cấp";
            dataGridView1.Columns[1].HeaderText = "Tên nhà cung cấp";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            dataGridView1.Columns[3].HeaderText = "Số điện thoại";
        }

        public void Create()
        {
            if (CheckEmptyInfo()) { 
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    tb_NCC NCC = new tb_NCC()
                    {
                        ma_ncc = Int32.Parse(textBox1.Text),
                        ten_ncc = textBox2.Text,
                        dia_chi = textBox3.Text,
                        dien_thoai = textBox4.Text
                    };
                    db.tb_NCC.Add(NCC);
                }
                else
                {
                    tb_NCC NCC = new tb_NCC()
                    {                       
                        ten_ncc = textBox2.Text,
                        dia_chi = textBox3.Text,
                        dien_thoai = textBox4.Text
                    };
                    db.tb_NCC.Add(NCC);
                }
      
                db.SaveChanges();
                LoadData();
            }
        }

        public void Edit()
        {
            if (CheckEmptyInfo())
            {
                int ma_cc1 = Convert.ToInt32(textBox1.Text);
                tb_NCC Ncc = db.tb_NCC.Where(p => p.ma_ncc == ma_cc1).SingleOrDefault();

                Ncc.ten_ncc = textBox2.Text;
                Ncc.dia_chi = textBox3.Text;
                Ncc.dien_thoai = textBox4.Text;
                db.SaveChanges();
                LoadData();
            }
        }

        public void Del()
        {
            int ma_cc1 = Convert.ToInt32(textBox1.Text);
            tb_NCC Ncc = db.tb_NCC.Where(p => p.ma_ncc == ma_cc1).SingleOrDefault();
            db.tb_NCC.Remove(Ncc);
            db.SaveChanges();
            LoadData();
        }

        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Create();
            Clear();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Enabled = false;
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = Convert.ToString(row.Cells["ma_ncc"].Value);
            textBox2.Text = Convert.ToString(row.Cells["ten_ncc"].Value);
            textBox3.Text = Convert.ToString(row.Cells["dia_chi"].Value);
            textBox4.Text = Convert.ToString(row.Cells["dien_thoai"].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Del();
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Edit();
            Clear();
        }
    }
}
