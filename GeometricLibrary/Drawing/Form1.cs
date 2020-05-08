using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeometricLibrary;

namespace Drawing
{
    public partial class Form1 : Form
    {
        private double ratio = 75;
        public Form1()
        {
            InitializeComponent();
        }

        private System.Drawing.Point ConvertToScreen(GeometricLibrary.Point point)
        {
            return new System.Drawing.Point(
                (int)Math.Round(point.X * ratio),
                (int)Math.Round(ClientSize.Height - point.Y * ratio));
        }
    }
}
