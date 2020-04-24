using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка нажата");
        }

        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            label5.Text = e.KeyCode.ToString();
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                e.IsInputKey = true;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            label6.Text = e.KeyCode.ToString();

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                button1.ContextMenuStrip.Show(button1,
                    new Point(0, button1.Height),
                    ToolStripDropDownDirection.BelowRight);

        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label7.Text = e.KeyChar.ToString();
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            label8.Text = e.KeyCode.ToString();
        }
    }
}
