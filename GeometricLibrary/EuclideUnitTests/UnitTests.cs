using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometricLibrary;
using System.IO;

namespace EuclideUnitTests
{
    [TestClass]
    public class PointUnitTests
    {
        [TestMethod]
        public void ConstructorTestMethod()
        {
            var p = GetTestPoint();

            Assert.AreEqual(3, p.X);
            Assert.AreEqual(2, p.Y);
        }

        [TestMethod]
        public void ToStringTestMethod()
        {
            //Arrange
            var p = GetTestPoint();

            //Act
            var str = p.ToString();

            //Assert
            Assert.AreEqual("(3; 2)", str);

        }

        [TestMethod]
        public void IsInsideSegmentTestMethod()
        {
            var a = new Point(2, 1);
            var b = new Point(4, 2);
            var c = new Point(3, 1.5);
            var d = new Point(0, 0);
            var p = GetTestPoint();

            var s = new Segment(a, b);

            Assert.IsTrue(a.IsInsideSegment(s));
            Assert.IsTrue(b.IsInsideSegment(s));
            Assert.IsTrue(c.IsInsideSegment(s));
            Assert.IsFalse(d.IsInsideSegment(s));
            Assert.IsFalse(p.IsInsideSegment(s));
        }

        [TestMethod]
        public void CloneTestMethod()
        {
            var p = GetTestPoint();
            var q = p.Clone() as Point;

            Assert.AreEqual(3, q.X);
            Assert.AreEqual(2, q.Y);
            Assert.AreNotSame(p, q);           
        }

        [TestMethod]
        public void PrintInfoTestMethod()
        {
            var p = GetTestPoint();
            var lines = new[] { "Точка (3; 2)" };

            var oldOut = Console.Out;

            using (var file = new FileStream("test.txt", FileMode.Create))
            {
                using (TextWriter writer = new StreamWriter(file))
                {
                    Console.SetOut(writer);
                    p.PrintInfo();                   
                }
            }

            Console.SetOut(oldOut);

            using( var file = new FileStream("test.txt", FileMode.Open))
            {
                using(TextReader reader = new StreamReader(file))
                {
                    var i = 0;

                    while(!(reader as StreamReader).EndOfStream)
                        Assert.AreEqual(lines[i++], reader.ReadLine());

                    Assert.AreEqual(lines.Length, i);
                }
            }

            File.Delete("test.txt");
        }

        private Point GetTestPoint()
        {
            return new Point(3, 2);
        }
    }

    [TestClass]
    public class SegmentUnitTests
    {
        [TestMethod]
        public void SegmentConstructorUnitTestMethod()
        {
            var a = new Point(1, 2);
            var b = new Point(-3, 4);

            var s = new Segment(a, b);

            Assert.ReferenceEquals(a, s.A);
            Assert.ReferenceEquals(b, s.B);
        }

        [TestMethod]
        public void SegmentCloneTestMethod()
        {
            var s = new Segment(new Point(1, 1), new Point(-2, 3));
            var sClone = s.Clone() as Segment;

            Assert.AreEqual(s.A.X, sClone.A.X);
            Assert.AreEqual(s.A.Y, sClone.A.Y);
            Assert.AreEqual(s.B.X, sClone.B.X);
            Assert.AreEqual(s.B.Y, sClone.B.Y);
            Assert.AreNotSame(s.A, sClone.A);
            Assert.AreNotSame(s.B, sClone.B);
            Assert.AreNotSame(s, sClone);
        }
    }

    [TestClass]
    public class GeometryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTriangleExceptionTest()
        {
            var t = Geometry.CreateTriangle(
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 2)
                );
        }
    }
}
