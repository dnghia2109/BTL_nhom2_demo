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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            textBox_screen.Text = textBox_screen.Text + "0";
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            textBox_screen.Text = textBox_screen.Text + "1";
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            textBox_screen.Text = textBox_screen.Text + "2";
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            textBox_screen.Text = textBox_screen.Text + "3";
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            textBox_screen.Text = textBox_screen.Text + "4";
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            textBox_screen.Text = textBox_screen.Text + "5";
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            textBox_screen.Text = textBox_screen.Text + "6";
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            textBox_screen.Text = textBox_screen.Text + "7";
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            textBox_screen.Text = textBox_screen.Text + "8";
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            textBox_screen.Text = textBox_screen.Text + "9";
        }

        private void button_point_Click(object sender, EventArgs e)
        {
            textBox_screen.Text = textBox_screen.Text + ".";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_screen.Clear();
        }

        float data_1, data_2;
        string pheptinh;

        private void button_equal_Click(object sender, EventArgs e)
        {
            if (pheptinh == "sum")
            {
                data_2 = data_1 + float.Parse(textBox_screen.Text);
                textBox_screen.Text = data_2.ToString();
            }

            if (pheptinh == "sub")
            {
                data_2 = data_1 - float.Parse(textBox_screen.Text);
                textBox_screen.Text = data_2.ToString();
            }

            if (pheptinh == "mul")
            {
                data_2 = data_1 * float.Parse(textBox_screen.Text);
                textBox_screen.Text = data_2.ToString();
            }

            if (pheptinh == "div")
            {
                data_2 = data_1 / float.Parse(textBox_screen.Text);
                textBox_screen.Text = data_2.ToString();
            }

            if (pheptinh == "pow")
            {
                data_2 = (float)Math.Pow((double)data_1, double.Parse(textBox_screen.Text));
                textBox_screen.Text = data_2.ToString();
            }

            if (pheptinh == "sqrt")
            {
                data_2 = (float)Math.Sqrt(data_1);
                textBox_screen.Text = data_2.ToString();
            }

            if (pheptinh == "1/x")
            {
                data_2 = (float)Math.Round((1/data_1), 4);
                textBox_screen.Text = data_2.ToString();
            }

            if (pheptinh == "mod")
            {
                data_2 = data_1 % float.Parse(textBox_screen.Text);
                textBox_screen.Text = data_2.ToString();
            }

        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            pheptinh = "sum";
            data_1 = float.Parse(textBox_screen.Text);
            textBox_screen.Clear();
        }

        private void button_sub_Click(object sender, EventArgs e)
        {
            pheptinh = "sub";
            data_1 = float.Parse(textBox_screen.Text);
            textBox_screen.Clear();
        }

        private void button_mul_Click(object sender, EventArgs e)
        {
            pheptinh = "mul";
            data_1 = float.Parse(textBox_screen.Text);
            textBox_screen.Clear();
        }

        private void button_div_Click(object sender, EventArgs e)
        {
            pheptinh = "div";
            data_1 = float.Parse(textBox_screen.Text);
            textBox_screen.Clear();
        }

        private void button_pow_Click(object sender, EventArgs e)
        {
            pheptinh = "pow";
            data_1 = float.Parse(textBox_screen.Text);
            textBox_screen.Clear();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            pheptinh = "1/x";
            data_1 = float.Parse(textBox_screen.Text);
            textBox_screen.Clear();
        }

        private void button_mod_Click(object sender, EventArgs e)
        {
            pheptinh = "mod";
            data_1 = float.Parse(textBox_screen.Text);
            textBox_screen.Clear();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            pheptinh = "div";
            data_1 = float.Parse(textBox_screen.Text);
            textBox_screen.Clear();
        }

        private void textBox_screen_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_sqrt_Click(object sender, EventArgs e)
        {
            pheptinh = "sqrt";
            data_1 = float.Parse(textBox_screen.Text);
            textBox_screen.Clear();
        }
    }
}
