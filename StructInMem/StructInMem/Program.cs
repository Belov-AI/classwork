using System;
using System.Runtime.InteropServices;

namespace StructInMem
{
    struct TestStruct1
    {
        public short First;
        public byte Second;
        public byte Third;
    }

    struct TestStruct2
    {
        public byte Third;
        public short First;
        public byte Second;
    }

    class Program
    {
        static void Main()
        {
            var struct1 = new TestStruct1();

            Console.WriteLine("Размер струкуры TestStruct1 в байтах: " +
                Marshal.SizeOf(struct1));

            var struct2 = new TestStruct2();

            Console.WriteLine("Размер струкуры TestStruct2 в байтах: " +
                Marshal.SizeOf(struct2));

            Console.ReadKey();
        }
    }
}
