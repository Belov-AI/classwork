using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosureTrap
{
    class Program
    {
        static void Main(string[] args)
        {
            double scalar = 3;
            Func<double, double> scale = x => x * scalar;

            Console.WriteLine(scale(5));
            Console.WriteLine();

            var call = CallCount();

            call();
            call();
            call();
            Console.WriteLine();

            var funcs = new Func<int>[3];
            //funcs[0] = () => 0;
            //funcs[1] = () => 1;
            //funcs[2] = () => 2;

            for (var i = 0; i < funcs.Length; i++)
                funcs[i] = () => i;

            foreach (var f in funcs)
                Console.WriteLine(f());


            Console.ReadKey();
        }

        static Action CallCount()
        {
            var counter = 0;
            return () => Console.WriteLine(++counter);
        }
    }
}
