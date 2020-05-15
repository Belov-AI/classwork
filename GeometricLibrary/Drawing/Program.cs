using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeometricLibrary;

namespace Drawing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var c = new GeometricLibrary.Point(4, 4);

            //var orig = new Triangle(
            //    new GeometricLibrary.Point(2, 1),
            //    new GeometricLibrary.Point(7, 1),
            //    new GeometricLibrary.Point(7, 5));

            //var rot = orig.Clone() as Triangle;
            //rot.Rotate(c, 30);


            //var canvas = new Form1(c, orig, rot);
            
            Application.Run(new StartForm());
        }
    }
}
