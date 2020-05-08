using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using(var pen = new Pen(Color.Red, 10))
            {
                g.DrawLine(pen, 5, 5, 200, 200);
                g.DrawRectangle(pen, 5, 5, 300, 200);
            }

            g.FillEllipse(Brushes.Blue, 
                ClientSize.Width / 2 - 50, ClientSize.Height / 2 - 50, 
                100, 100);

            using (var pen = new Pen(Color.Green, 6))
            {
                g.DrawEllipse(pen, 3, 3, ClientSize.Width - 6,
                    ClientSize.Height - 6);
            }
            
        }
    }
}
