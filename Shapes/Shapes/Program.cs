using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Point(1, 2);
            Console.WriteLine(p);

            var circle = new Circle(p, 1);
            //circle.PrintInfo();

            var rectangle = new Rectangle(new Point(1, 1), new Point(3, 4));
            //rectangle.PrintInfo();

            var shapes = new Shape[] { circle, rectangle };

            foreach (var shape in shapes)
                shape.PrintInfo();

            Console.ReadKey();
        }
    }
}
