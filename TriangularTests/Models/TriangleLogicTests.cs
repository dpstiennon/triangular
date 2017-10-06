using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangular.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangular.Models.Tests
{
    [TestClass()]
    public class TriangleLogicTests
    {
        private TriangleLogic classifier;

        [TestInitialize()]
        public void Setup()
        {
            classifier = new TriangleLogic();
        }

        private List<decimal> TestTriangle(double a, double b, double c)
        {
            return new List<decimal> { new decimal(a), new decimal(b), new decimal(c)};
        }

        [TestMethod()]
        public void DetectsEquilateralTriangle()
        {
            var equilateral = TestTriangle(45, 45, 45);
            var result = classifier.Classify(equilateral);
            Assert.AreEqual("Equilateral", result);
        }

        [TestMethod()]
        public void DetectsIsoscelesTriangle()
        {
            var iso = TestTriangle(2, 16.3, 16.3);
            var result = classifier.Classify(iso);
            Assert.AreEqual("Isosceles", result);
        }

        [TestMethod()]
        public void DetectsRightTriangle()
        {
            var right = TestTriangle(3, 4, 5);
            var result = classifier.Classify(right);
            Assert.AreEqual("Scalene: Right", result);
        }

        [TestMethod()]
        public void DetectsObtuseTriangle()
        {
            var right = TestTriangle(2.7, 4, 5);
            var result = classifier.Classify(right);
            Assert.AreEqual("Scalene: Obtuse", result);
        }

        [TestMethod()]
        public void DetectsAcuteTriangle()
        {
            var right = TestTriangle(3.1, 4, 5);
            var result = classifier.Classify(right);
            Assert.AreEqual("Scalene: Acute", result);
        }

        [TestMethod]
        public void SquareIsNotATriangle()
        {
            var square = new List<decimal> {new decimal(4), new decimal(4), new decimal(4), new decimal(4)};
            var result = classifier.Classify(square);
            Assert.AreEqual("Not a Triangle", result);
        }

        [TestMethod]
        public void TwoLinesAreNotATriangle()
        {
            var twoLines = new List<decimal> {new decimal(2.3), new decimal(2.3)};
            var result = classifier.Classify(twoLines);
            Assert.AreEqual("Not a Triangle", result);
        }

        [TestMethod]
        public void SideLength0IsNotATriangle()
        {
            var zeroSide = TestTriangle(3, 2, 0);
            var result = classifier.Classify(zeroSide);
            Assert.AreEqual("Not a Triangle", result);
        }

        [TestMethod]
        public void SideLengthNegativeIsNotATriangle()
        {
            var negativeSide = TestTriangle(3, 2, -1);
            var result = classifier.Classify(negativeSide);
            Assert.AreEqual("Not a Triangle", result);
        }

        [TestMethod]
        public void LongSideTooLongIsNotATriangle()
        {
            var longSide = TestTriangle(3, 2, 5);
            var result = classifier.Classify(longSide);
            Assert.AreEqual("Not a Triangle", result);
        }






    }
}