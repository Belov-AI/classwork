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
    public partial class Form2 : Form
    {
        private Form1 master;
        public Form2(Form1 f)
        {
            InitializeComponent();
            master = f;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            (master.Controls["button3"] as Button).Text = "Открыть вторую форму";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form4();

            this.AddOwnedForm(f);
            f.Show();
        }
    }
}
