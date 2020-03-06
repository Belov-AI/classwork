using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometricLibrary;

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
    }
}
