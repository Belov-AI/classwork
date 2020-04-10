using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            listBox1.Items.Add("Глава");
            listBox1.Items.Add("Параграф");
            listBox1.Items.Add("Раздел");

            comboBox1.Items.Add("Microsoft San Serif");
            comboBox1.Items.Add("Times New Roman");
            comboBox1.Items.Add("Courier New");
            comboBox1.SelectedIndex = 0;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
            textBox1.Text = "";
        }

        private void ChangeFontStyle(object sender, EventArgs e)
        {
            var fontstyle = FontStyle.Regular;

            if (checkBox1.Checked)
                fontstyle |= FontStyle.Bold;

            if (checkBox2.Checked)
                fontstyle |= FontStyle.Italic;

            if (checkBox3.Checked)
                fontstyle |= FontStyle.Underline;

            label1.Font = new Font(
                label1.Font.FontFamily,
                label1.Font.Size,
                fontstyle);
        }

        private void ChangeSize(object sender, EventArgs e)
        {
            var radiobutton = sender as RadioButton;
            int size = int.Parse(radiobutton.Text.Split()[0]);
            label1.Font = new Font(
                label1.Font.FontFamily,
                size,
                label1.Font.Style);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = listBox1.SelectedItem.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fontfamilyName = comboBox1.SelectedItem.ToString();

            label1.Font = new Font(
                fontfamilyName,
                label1.Font.Size,
                label1.Font.Style);
        }
    }
}
