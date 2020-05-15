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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double cX, cY;
            if (!double.TryParse(textBox1.Text, out cX))
                return; 
            if (!double.TryParse(textBox1.Text, out cY))
                return;

            var c = new GeometricLibrary.Point(cX, cY);

            
        }
    }
}
