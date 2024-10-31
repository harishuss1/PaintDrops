using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaintDropSimulation;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDropSimulation.Tests
{
    [TestClass()]
    public class PaintDropTests
    {
        [TestMethod]
        public void PaintDrop_Constructor()
        {
            var circle1 = ShapesFactory.CreateCircle(100, 100, 50, new Colour(255, 0, 0));
            var paintDrop1 = new PaintDrop(circle1);


            Assert.AreEqual(circle1, paintDrop1.Circle);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PaintDrop_NullCircle_ShouldThrowException()
        {
            var paintDrop2 = new PaintDrop(null);

        }

        [TestMethod]
        public void PaintDrop_Marble_ShouldRecalculateVerticesCorrectly()
        {
            var circle1 = ShapesFactory.CreateCircle(100, 100, 50, new Colour(255, 0, 0));
            var circle2 = ShapesFactory.CreateCircle(150, 150, 40, new Colour(0, 255, 0));
            var paintDrop1 = new PaintDrop(circle1);
            var paintDrop2 = new PaintDrop(circle2);

            var initialVertices = new Vector[circle1.Vertices.Length];
            for (int i = 0; i < circle1.Vertices.Length; i++)
            {
                initialVertices[i] = circle1.Vertices[i];
            }

            paintDrop1.Marble(paintDrop2);

            for (int i = 0; i < initialVertices.Length; i++)
            {
                Assert.AreNotEqual(initialVertices[i], circle1.Vertices[i], $"Vertex {i} was not recalculated as expected.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PaintDrop_Marble_NullOther_ShouldThrowArgumentException()
        {
            var circle1 = ShapesFactory.CreateCircle(100, 100, 50, new Colour(255, 0, 0));
            var paintDrop1 = new PaintDrop(circle1);

            paintDrop1.Marble(null);
        }
    }
}