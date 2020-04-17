using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Controls
{
    public partial class Form1 : Form
    {
        int pictureNumber = 7;
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

        private void ChangePicture(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button.Text == "<<")
                pictureNumber--;
            else
                pictureNumber++;

            if (pictureNumber == 8)
                pictureNumber = 1;
            else if (pictureNumber == 0)
                pictureNumber = 7;

            pictureBox1.Image = Properties.Resources.ResourceManager.GetObject(
                "pic" + pictureNumber.ToString()) as Image;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Пуск")
            {
                timer1.Enabled = true;
                button4.Text = "Стоп";
            }
                
            else
            {
                timer1.Enabled = false;
                button4.Text = "Пуск";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.PerformStep();

                if (progressBar1.Value % 20 == 0)
                    ChangePicture(button3, new EventArgs());
            }
            else
            {
                timer1.Enabled = false;
                progressBar1.Value = 0;
                button4.Text = "Пуск";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Простой текст|*.txt|Форматированный текст|*.rtf";

            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
                if (openFileDialog1.FilterIndex == 1)
                    richTextBox1.Text = File.ReadAllText(
                        openFileDialog1.FileName, Encoding.Default);
                else
                    richTextBox1.LoadFile(openFileDialog1.FileName);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG|*.jpg|PNG|*.png|TIFF|*.tif";

            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
