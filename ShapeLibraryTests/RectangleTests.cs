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
    public class RectangleTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            string colour = "Red";
            Rectangle rec = new Rectangle(2, 4, 200, 400, colour);
            Assert.AreEqual(rec.X, 2);
            Assert.AreEqual(rec.Y, 4);
            Assert.AreEqual(rec.Width, 200);
            Assert.AreEqual(rec.Height, 400);
            Assert.AreEqual(rec.Colour, colour);
        }

        [TestMethod]
        public void Rectangle_Vertices_ShouldReturnCorrectVertices()
        {
            Rectangle rectangle = new Rectangle(10, 20, 30, 40, "Red");

            Vector[] vertices = rectangle.Vertices;

            Assert.AreEqual(4, vertices.Length);
            Assert.AreEqual(new Vector(10, 20), vertices[0]); 
            Assert.AreEqual(new Vector(40, 20), vertices[1]); 
            Assert.AreEqual(new Vector(40, 60), vertices[2]); 
            Assert.AreEqual(new Vector(10, 60), vertices[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Negative values for height and width")]
        public void NegativeConstructorWidthTest()
        {
            string colour = "Red";
            Rectangle rec = new Rectangle(2, 4, -200, 400, colour);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Negative values for height and width")]
        public void NegativeConstructorHeightTest()
        {
            string colour = "Red";
            Rectangle rec = new Rectangle(2, 4, 20, -40, colour);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Negative values for height and width")]
        public void NegativeConstructorWidthZeroTest()
        {
            string colour = "Red";
            Rectangle rec = new Rectangle(2, 4, 0, 40, colour);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Negative values for height and width")]
        public void NegativeConstructorHeightZeroTest()
        {
            string colour = "Red";
            Rectangle rec = new Rectangle(2, 4, 20, 0, colour);
        }

        [TestMethod]
        public void Rectangle_Vertices_ShouldBeCachedAfterFirstAccess()
        {
            Rectangle rectangle = new Rectangle(10, 20, 30, 40, "Blue");

            var firstAccess = rectangle.Vertices;
            var secondAccess = rectangle.Vertices;

            Assert.AreSame(firstAccess, secondAccess); 
        }

    }
}