using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestMethod]
        public void Constructor_Test()
        {
            Vector expectedcenter = new Vector(50,50);
            Colour colour = new Colour(200,200,200);
            Circle cir = new Circle(50,50,200,colour);

            Assert.IsNotNull(cir);
            Assert.AreEqual(cir.Center, expectedcenter);
            Assert.AreEqual(cir.Radius, 200);
            Assert.AreEqual(cir.Colour, colour);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Radius cannot be negative.")]

        public void Constructor_Test_Negative_Radius()
        {
            Vector expectedcenter = new Vector(50, 50);
            Colour colour = new Colour(200, 200, 200);
            Circle cir = new Circle(50, 50, -200, colour);

        }

        [TestMethod]
        public void TestCircleVertices_Positive()
        {
            float x = 0;
            float y = 0;
            float radius = 5;
            Colour colour = new Colour(255, 0, 0);

            Circle circle = new Circle(0, 0, 5, colour);
            Vector[] vertices = circle.Vertices;

            Assert.AreEqual(50, vertices.Length);
            foreach (var vertex in vertices)
            {
                float distance = Vector.Magnitude(new Vector(vertex.X - x, vertex.Y - y));
                Assert.AreEqual(radius, distance, 0.01f);
            }
        }

        [TestMethod]
        public void CircleVertices_Return50Points()
        {
            float x = 0;
            float y = 0;
            float radius = 5;
            Colour colour = new Colour(255, 0, 0);

            Circle circle = new Circle(0, 0, 5, colour);
            Vector[] vertices = circle.Vertices;
            Assert.AreEqual(50, vertices.Length);
        }

        [TestMethod]
        public void CircleVerticies_4PointsReturnCorrectValue()
        {
            float x = 0;
            float y = 0;
            float radius = 5;
            Colour colour = new Colour(255, 0, 0);
            Circle circle = new Circle(0, 0, 5, colour);

            Vector[] vertices = circle.Vertices;

            Assert.AreEqual(50, vertices.Length);

            Vector expected0 = new Vector((float)(5 * Math.Cos(0 * 2 * Math.PI / 50)), (float)(5 * Math.Sin(0 * 2 * Math.PI / 50)));
            Vector expected12 = new Vector((float)(5 * Math.Cos(12 * 2 * Math.PI / 50)), (float)(5 * Math.Sin(12 * 2 * Math.PI / 50)));
            Vector expected24 = new Vector((float)(5 * Math.Cos(24 * 2 * Math.PI / 50)), (float)(5 * Math.Sin(24 * 2 * Math.PI / 50)));
            Vector expected37 = new Vector((float)(5 * Math.Cos(37 * 2 * Math.PI / 50)), (float)(5 * Math.Sin(37 * 2 * Math.PI / 50)));

            Assert.IsTrue(Math.Abs(vertices[0].X - expected0.X) < 0.01 && Math.Abs(vertices[0].Y - expected0.Y) < 0.01);
            Assert.IsTrue(Math.Abs(vertices[12].X - expected12.X) < 0.01 && Math.Abs(vertices[12].Y - expected12.Y) < 0.01);
            Assert.IsTrue(Math.Abs(vertices[24].X - expected24.X) < 0.01 && Math.Abs(vertices[24].Y - expected24.Y) < 0.01);
            Assert.IsTrue(Math.Abs(vertices[37].X - expected37.X) < 0.01 && Math.Abs(vertices[37].Y - expected37.Y) < 0.01);
        }

    
    
        [TestMethod]
            public void Circle_Vertices_ShouldBeCachedAfterFirstAccess()
            {
                Circle circle = new Circle(50, 50, 200, new Colour(200, 200, 200));

                var firstAccess = circle.Vertices;
                var secondAccess = circle.Vertices;

                Assert.AreSame(firstAccess, secondAccess);
            }




    }
}