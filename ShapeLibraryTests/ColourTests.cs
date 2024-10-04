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
    public class ColourTests
    {
        [TestMethod]
        public void Test_Colour_Constructor_Positive()
        {
            int red = 100, green = 150, blue = 200;

            Colour colour = new Colour(red, green, blue);

            Assert.AreEqual(red, colour.Red);
            Assert.AreEqual(green, colour.Green);
            Assert.AreEqual(blue, colour.Blue);
        }

        [TestMethod]
        public void Test_Colour_Constructor_Negative_BelowZero()
        {
            int red = -10, green = -20, blue = -30;

            Colour colour = new Colour(red, green, blue);

            Assert.AreEqual(0, colour.Red);
            Assert.AreEqual(0, colour.Green);
            Assert.AreEqual(0, colour.Blue);
        }

        [TestMethod]
        public void Test_Colour_Constructor_Negative_Above255()
        {
            int red = 300, green = 400, blue = 500;

            Colour colour = new Colour(red, green, blue);

            Assert.AreEqual(255, colour.Red);
            Assert.AreEqual(255, colour.Green);
            Assert.AreEqual(255, colour.Blue);
        }

        [TestMethod]
        public void Test_Colour_Addition_Positive()
        {
            Colour c1 = new Colour(100, 100, 100);
            Colour c2 = new Colour(50, 50, 50);

            Colour result = c1 + c2;

            Assert.AreEqual(150, result.Red);
            Assert.AreEqual(150, result.Green);
            Assert.AreEqual(150, result.Blue);
        }

        [TestMethod]
        public void Test_Colour_Addition_Negative_Overflow()
        {
            Colour c1 = new Colour(200, 200, 200);
            Colour c2 = new Colour(100, 100, 100);

            Colour result = c1 + c2;

            Assert.AreEqual(255, result.Red);  
            Assert.AreEqual(255, result.Green);
            Assert.AreEqual(255, result.Blue);
        }

        [TestMethod]
        public void Test_Colour_Subtraction_Positive()
        {
            Colour c1 = new Colour(100, 100, 100);
            Colour c2 = new Colour(50, 50, 50);

            Colour result = c1 - c2;

            Assert.AreEqual(50, result.Red);
            Assert.AreEqual(50, result.Green);
            Assert.AreEqual(50, result.Blue);
        }

        [TestMethod]
        public void Test_Colour_Subtraction_Negative_Underflow()
        {
            Colour c1 = new Colour(50, 50, 50);
            Colour c2 = new Colour(100, 100, 100);

            Colour result = c1 - c2;

            Assert.AreEqual(0, result.Red);  
            Assert.AreEqual(0, result.Green);
            Assert.AreEqual(0, result.Blue);
        }

        [TestMethod]
        public void Test_Colour_Multiplication_Positive()
        {
            Colour colour = new Colour(100, 100, 100);
            int scale = 2;

            Colour result = colour * scale;

            Assert.AreEqual(200, result.Red);
            Assert.AreEqual(200, result.Green);
            Assert.AreEqual(200, result.Blue);
        }

        [TestMethod]
        public void Test_Colour_Multiplication_Saturation()
        {
            Colour colour = new Colour(150, 150, 150);
            int scale = 2;

            Colour result = colour * scale;

            Assert.AreEqual(255, result.Red); 
            Assert.AreEqual(255, result.Green);
            Assert.AreEqual(255, result.Blue);
        }

        [TestMethod]
        public void Test_Colour_Equality_Positive()
        {
            Colour c1 = new Colour(100, 150, 200);
            Colour c2 = new Colour(100, 150, 200);

            Assert.IsTrue(c1 == c2);
        }

        [TestMethod]
        public void Test_Colour_Equality_Negative()
        {
            Colour c1 = new Colour(100, 150, 200);
            Colour c2 = new Colour(200, 150, 100);

            Assert.IsFalse(c1 == c2);
        }

        [TestMethod]
        public void Test_Colour_Inequality_Positive()
        {
            Colour c1 = new Colour(100, 150, 200);
            Colour c2 = new Colour(200, 150, 100);

            Assert.IsTrue(c1 != c2);
        }

        [TestMethod]
        public void Test_Colour_Inequality_Negative()
        {
            Colour c1 = new Colour(100, 150, 200);
            Colour c2 = new Colour(100, 150, 200);

            Assert.IsFalse(c1 != c2);
        }

        [TestMethod]
        public void Test_Colour_ToString_Positive()
        {
            Colour colour = new Colour(100, 150, 200);

            string result = colour.ToString();

            Assert.AreEqual("Colour(Red: 100, Green: 150, Blue: 200)", result);
        }

    }
}