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
        public void PaintDrop_Marble_ShouldRecalculateVertices()
        {
            var circle1 = ShapesFactory.CreateCircle(100, 100, 50, new Colour(255, 0, 0));
            var circle2 = ShapesFactory.CreateCircle(150, 150, 40, new Colour(0, 255, 0));
            var paintDrop1 = new PaintDrop(circle1);
            var paintDrop2 = new PaintDrop(circle2);

            paintDrop1.Marble(paintDrop2);

            Assert.AreNotEqual(circle1.Vertices, paintDrop2.Circle.Vertices);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PaintDrop_Marble_NullOther_ShouldThrowException()
        {
            var circle1 = ShapesFactory.CreateCircle(100, 100, 50, new Colour(255, 0, 0));
            var paintDrop1 = new PaintDrop(circle1);

            paintDrop1.Marble(null);

        }
    }
}