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
using System.Drawing.Drawing2D;

namespace Drawing
{
    public partial class Form1 : Form
    {
        GeometricLibrary.Point rotationCenter;
        Triangle originalTriangle;
        Triangle rotatedTriangle;
        private Graphics g;

        private double scale = 75;
        public Form1(
            GeometricLibrary.Point center, 
            Triangle original, 
            Triangle rotated)
        {
            InitializeComponent();

            rotationCenter = center;
            originalTriangle = original;
            rotatedTriangle = rotated;

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

        }

        private System.Drawing.Point ConvertToScreen(GeometricLibrary.Point point)
        {
            return new System.Drawing.Point(
                (int)Math.Round(point.X * scale),
                (int)Math.Round(ClientSize.Height - point.Y * scale));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            DrawPoint(rotationCenter, Color.Red, 5);
            DrawTriangle(originalTriangle, Color.Blue, 3, DashStyle.Solid);
            DrawTriangle(rotatedTriangle, Color.Green, 3, DashStyle.Dash);
        }

        private void DrawPoint(GeometricLibrary.Point p, Color color, int radius)
        {
            using(var brush = new SolidBrush(color))
            {
                var pixel = ConvertToScreen(p);

                var size = 2 * radius - 1;

                g.FillEllipse(
                    brush, pixel.X - radius, pixel.Y - radius, size, size);
            }
        }

        private void DrawTriangle(
            Triangle t, Color color, int penWidth, DashStyle dash)
        {
            using(var pen = new Pen(color, penWidth))
            {
                pen.DashStyle = dash;
                g.DrawLines(
                    pen, new[] {ConvertToScreen(t.A),
                        ConvertToScreen(t.B),
                        ConvertToScreen(t.C),
                        ConvertToScreen(t.A)});

            }
        }
    }
}
