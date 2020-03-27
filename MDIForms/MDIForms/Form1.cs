using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIForms
{
    public partial class Form1 : Form
    {
        private int number = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.Text = "Документ " + number++;
            form.MdiParent = this;
            form.Show();
        }
    }
}
