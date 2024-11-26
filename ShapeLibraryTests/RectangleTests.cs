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
            Colour colour = new Colour(200, 200, 200);
            Rectangle rec = new Rectangle(2, 4, 200, 400, new Colour(200, 200, 200));
            Assert.AreEqual(rec.X, 2);
            Assert.AreEqual(rec.Y, 4);
            Assert.AreEqual(rec.Width, 200);
            Assert.AreEqual(rec.Height, 400);
            Assert.AreEqual(rec.Colour, colour);
        }

        [TestMethod]
        public void Rectangle_Vertices_ShouldReturnCorrectVertices()
        {
            Rectangle rectangle = new Rectangle(10, 20, 30, 40, new Colour(200, 200, 200));

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
            Rectangle rec = new Rectangle(2, 4, -200, 400, new Colour(200, 200, 200));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Negative values for height and width")]
        public void NegativeConstructorHeightTest()
        {
            Rectangle rec = new Rectangle(2, 4, 20, -40, new Colour(200, 200, 200));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Negative values for height and width")]
        public void NegativeConstructorWidthZeroTest()
        {
            Rectangle rec = new Rectangle(2, 4, 0, 40, new Colour(200, 200, 200));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Negative values for height and width")]
        public void NegativeConstructorHeightZeroTest()
        {
            Rectangle rec = new Rectangle(2, 4, 20, 0, new Colour(200, 200, 200));
        }

        [TestMethod]
        public void Rectangle_Vertices_ShouldBeCachedAfterFirstAccess()
        {
            Rectangle rectangle = new Rectangle(10, 20, 30, 40, new Colour(200, 200, 200));

            var firstAccess = rectangle.Vertices;
            var secondAccess = rectangle.Vertices;

            Assert.AreSame(firstAccess, secondAccess); 
        }

        [TestMethod]
        public void Intersect_ShouldReturnTrue_WhenRectanglesOverlap()
        {
            Rectangle rect1 = new Rectangle(0, 0, 10, 10, new Colour(255, 0, 0));
            Rectangle rect2 = new Rectangle(5, 5, 10, 10, new Colour(0, 255, 0));

            bool result = rect1.Intersect(rect2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Intersect_ShouldReturnFalse_WhenRectanglesDoNotOverlap()
        {
            Rectangle rect1 = new Rectangle(0, 0, 10, 10, new Colour(255, 0, 0));
            Rectangle rect2 = new Rectangle(20, 20, 10, 10, new Colour(0, 255, 0));

            bool result = rect1.Intersect(rect2);

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void Intersect_ShouldReturnFlase_WhenRectanglesTouchAtEdges()
        {
            Rectangle rect1 = new Rectangle(0, 0, 10, 10, new Colour(255, 0, 0));
            Rectangle rect2 = new Rectangle(10, 0, 10, 10, new Colour(0, 255, 0));

            bool result = rect1.Intersect(rect2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Intersect_ShouldReturnFalse_WhenRectanglesTouchAtCorners()
        {
            Rectangle rect1 = new Rectangle(0, 0, 10, 10, new Colour(255, 0, 0));
            Rectangle rect2 = new Rectangle(10, 10, 10, 10, new Colour(0, 255, 0));

            bool result = rect1.Intersect(rect2);

            Assert.IsFalse(result);
        }

    }
}