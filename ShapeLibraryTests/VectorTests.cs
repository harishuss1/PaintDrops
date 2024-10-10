using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary.Tests
{
    [TestClass()]
    public class VectorTests
    {
        [TestMethod]
        public void TestConstructor_PositiveValues()
        {
            Vector v = new Vector(3, 4);

            Assert.AreEqual(3, v.X);
            Assert.AreEqual(4, v.Y);
        }
        [TestMethod]
        public void TestVectorAddition_Positive()
        {
            Vector v1 = new Vector(1, 2);
            Vector v2 = new Vector(3, 4);
            Vector result = v1 + v2;

            Assert.AreEqual(4, result.X);
            Assert.AreEqual(6, result.Y);
        }


        [TestMethod]
        public void TestVectorAddition_Negative()
        {
            Vector v1 = new Vector(-1, -2);
            Vector v2 = new Vector(-3, -4);
            Vector result = v1 + v2;

            Assert.AreEqual(-4, result.X);
            Assert.AreEqual(-6, result.Y);
        }

        [TestMethod]
        public void TestVectorSubtraction_Positive()
        {
            Vector v1 = new Vector(5, 7);
            Vector v2 = new Vector(3, 4);
            Vector result = v1 - v2;

            Assert.AreEqual(2, result.X);
            Assert.AreEqual(3, result.Y);
        }

        [TestMethod]
        public void TestVectorSubtraction_Negative()
        {
            Vector v1 = new Vector(-5, -7);
            Vector v2 = new Vector(-3, -4);
            Vector result = v1 - v2;

            Assert.AreEqual(-2, result.X);
            Assert.AreEqual(-3, result.Y);
        }

        [TestMethod]
        public void TestVectorMultiplication_PositiveFloat()
        {
            Vector v = new Vector(2, 3);
            float scalar = 2;
            Vector result = v * scalar;

            Assert.AreEqual(4, result.X);
            Assert.AreEqual(6, result.Y);
        }

        [TestMethod]
        public void TestVectorMultiplication_NegativeFloat()
        {
            Vector v = new Vector(-2, 3);
            float scalar = 2;
            Vector result = v * scalar;
            Assert.AreEqual(-4, result.X);
            Assert.AreEqual(6, result.Y);
        }

        [TestMethod]
        public void TestVectorMultiplication_PositiveInt()
        {
            Vector v = new Vector(2, 3);
            int scalar = 2;
            Vector result = v * scalar;

            Assert.AreEqual(4, result.X);
            Assert.AreEqual(6, result.Y);
        }

        [TestMethod]
        public void TestVectorMultiplication_NegativeInt()
        {
            Vector v = new Vector(-2, 3);
            int scalar = 2;
            Vector result = v * scalar;
            Assert.AreEqual(-4, result.X);
            Assert.AreEqual(6, result.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestVectorDivision_ByZero()
        {
            Vector v = new Vector(2, 3);
            float scalar = 0;
            Vector result = v / scalar;
        }

        [TestMethod]
        public void TestVectorDivision_Positive()
        {
            Vector v = new Vector(4, 6);
            float scalar = 2;
            Vector result = v / scalar;

            Assert.AreEqual(2, result.X);
            Assert.AreEqual(3, result.Y);
        }

        [TestMethod]
        public void TestVectorDivision_Negative()
        {
            Vector v = new Vector(-4, -6);
            float scalar = 2;
            Vector result = v / scalar;

            Assert.AreEqual(-2, result.X);
            Assert.AreEqual(-3, result.Y);
        }

        [TestMethod]
        public void TestVectorDivision_ByFloat()
        {
            Vector v = new Vector(6, 8);
            float scalar = 2f;
            Vector result = v / scalar;

            Assert.AreEqual(3, result.X);
            Assert.AreEqual(4, result.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestVectorDivision_ByZeroFloat()
        {
            Vector v = new Vector(6, 8);
            float scalar = 0f;
            Vector result = v / scalar;  // Should throw exception
        }

        [TestMethod]
        public void TestMagnitude_Positive()
        {
            Vector v = new Vector(3, 4);
            float result = Vector.Magnitude(v);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestMagnitude_Negative()
        {
            Vector v = new Vector(-3, -4);
            float result = Vector.Magnitude(v);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestNormalize_Positive()
        {
            Vector v = new Vector(3, 4);
            Vector result = Vector.Normalize(v);

            Assert.AreEqual(0.6f, result.X, 0.0001f);
            Assert.AreEqual(0.8f, result.Y, 0.0001f);
        }


        [TestMethod]
        public void TestNormalize_ZeroVector()
        {
            Vector v = new Vector(0, 0);
            Vector result = Vector.Normalize(v);
            Assert.AreEqual(v, new Vector(0,0));

        }

        [TestMethod]
        public void Test_Colour_ToString_Positive()
        {
            Vector v = new Vector(3, 4);
            string result = v.ToString();
            Assert.AreEqual("Vector :3,4", result);
        }

    }
}