using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {
        private Form2 form;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Кнопка")
            {
                label1.Text = "Кнопка нажата";
                button1.Text = "Сброс";
            }
            else
            {
                label1.Text = "Нажми кнопку";
                button1.Text = "Кнопка";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (form == null || form.IsDisposed)
            {
                form = new Form2(this);
                ShowForm2();
            }
            else if (button3.Text == "Скрыть вторую форму")
            {
                form.Hide();
                button3.Text = "Открыть вторую форму";
            }
            else
                ShowForm2();
        }

        private void ShowForm2()
        {
            form.Show();
            button3.Text = "Скрыть вторую форму";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dialog = new Form3();

            if (dialog.ShowDialog() == DialogResult.OK)
                this.Text = (dialog.Controls["textBox1"] as TextBox).Text;
           
        }
    }
}
