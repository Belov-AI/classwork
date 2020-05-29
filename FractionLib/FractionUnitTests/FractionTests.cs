using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FractionLib;

namespace FractionUnitTests
{
    [TestClass]
    public class FractionTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var a = new Fraction(-1, 2);

            Assert.AreEqual(-1, a.Numerator);
            Assert.AreEqual(2, a.Denominator);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorExceptionTest()
        {
            var a = new Fraction(1, 0);
        }

        [TestMethod]
        public void DenominatorSetTest()
        {
            var a = new Fraction(-1, 2);
            a.Denominator = 5;

            Assert.AreEqual(5, a.Denominator);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DenominatorSetExceptionTest()
        {
            var a = new Fraction(-1, 2);
            a.Denominator = 0;
        }

        [TestMethod]
        public void ValueTest()
        {
            var a = new Fraction(1, 2);

            Assert.AreEqual(0.5, a.Value, 1E-13);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var a = new Fraction(-3, 8);

            Assert.AreEqual("-3/8", a.ToString());
        }

        [TestMethod]
        public void EqualsTest()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(3, 6);
            var c = new Fraction(1, 3);

            Assert.IsTrue(a.Equals(b));
            Assert.IsFalse(a.Equals(c));

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void EqualsExceptionTest()
        {
            var a = new Fraction(1, 2);
            
            a.Equals("1/2");
        }

        [TestMethod]
        public void EqualityOperatorTest()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(3, 6);
            var c = new Fraction(1, 3);

            Assert.IsTrue(a == b);
            Assert.IsFalse(a != b);

            Assert.IsFalse(a == c);
            Assert.IsTrue(a != c);

        }

        [TestMethod]
        public void SumOperatorTest()
        {
            var a = new Fraction(1, 2);
            var b = new Fraction(-1, 3);
            var c = new Fraction(1, 6);

            Assert.IsTrue(a + b == c);
        }
    }
}
