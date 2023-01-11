using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1921050436_LaiDuyNghia_B1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtAccountName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAccountName.Text) || (String.IsNullOrEmpty(txtPassword.Text)) || (String.IsNullOrEmpty(txtIdAccount.Text)))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                ListViewItem lvi = new ListViewItem(txtAccountName.Text);

                lvi.SubItems.Add(txtPassword.Text);
                lvi.SubItems.Add(txtIdAccount.Text);
                //Hiện lên listview
                listView_1.Items.Add(lvi);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            listView_1.Items.Remove(listView_1.SelectedItems[0]);
        }

        private void listView_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView_1.FullRowSelect = true;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
