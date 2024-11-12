using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaintDropSimulation;
using PatternGenerationLib;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDropSimulation.Tests
{
    [TestClass()]
    public class SurfaceTests
    {

        [TestMethod]
        public void Surface_Constructor()
        {
            int width = 100;
            int height = 100;
            var surface = new Surface(width, height);

            Assert.AreEqual(width, surface.Width);
            Assert.AreEqual(height, surface.Height);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Surface_Constructor_WidthNegative()
        {
            var surface = new Surface(-100, 100);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Surface_Constructor_HeightNegative()
        {
            var surface = new Surface(100, -100);
            
        }

        [TestMethod]
        public void Surface_AddPaintDrop_ShouldAddToList()
        {
            var surface = new Surface(100,100);
            var circle = ShapesFactory.CreateCircle(100, 100, 50, new Colour(200, 0, 0));
            var drop = new PaintDrop(circle);

            surface.AddPaintDrop(drop);

            Assert.AreEqual(1, surface.Drops.Count);
            Assert.AreSame(drop, surface.Drops[0]);
        }

        [TestMethod]
        public void Surface_AddPaintDrop_ShouldMarbleOtherDrops()
        {
            var surface = new Surface(100, 100);
            var drop1 = new PaintDrop(ShapesFactory.CreateCircle(100, 100, 50, new Colour(255, 0, 0)));
            var drop2 = new PaintDrop(ShapesFactory.CreateCircle(150, 150, 50, new Colour(0, 255, 0)));

            surface.AddPaintDrop(drop1);
            surface.AddPaintDrop(drop2);

            Assert.AreNotEqual(drop1.Circle.Vertices, drop2.Circle.Vertices); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Surface_AddPaintDrop_Null_ShouldThrowArgumentNullException()
        {
            var surface = new Surface(100, 100);

            surface.AddPaintDrop(null);

        }

        [TestMethod]
        public void Surface_ShouldStartWithNoPaintDrops()
        {
            var surface = new Surface(100,100);

            Assert.AreEqual(0, surface.Drops.Count);
        }

        [TestMethod]
        public void Surface_AddPaintDrop_ShouldNotMarbleFirstDrop()
        {
            var surface = new Surface(100,100);
            var drop = new PaintDrop(ShapesFactory.CreateCircle(100, 100, 50, new Colour(255, 0, 0)));

            surface.AddPaintDrop(drop);

            Assert.AreEqual(1, surface.Drops.Count);
            Assert.AreEqual(50, drop.Circle.Radius);  
        }

        [TestMethod]
        public void GeneratePaintDropPattern_ShouldGeneratePatternAndAddToSurface()
        {
            var surface = PaintDropSimulationFactory.CreateSurface(500, 500);
            var patternGenerator = new PhyllotaxisPatternGeneration(10);
            surface.PatternGeneration += patternGenerator.CalculatePatternPoint;

            surface.GeneratePaintDropPattern(50, new Colour(0, 0, 255));

            Assert.AreEqual(1, surface.Drops.Count, "new paint drop should be added to the surface.");
        }

        [TestMethod]
        public void GeneratePaintDropPattern_ShouldRestartPatternAfterReset()
        {
            var surface = PaintDropSimulationFactory.CreateSurface(500, 500);
            var patternGenerator = new PhyllotaxisPatternGeneration(10);
            surface.PatternGeneration += patternGenerator.CalculatePatternPoint;

            surface.GeneratePaintDropPattern(50, new Colour(0, 0, 255));
            patternGenerator._currentPointIndex = 0;
            surface.GeneratePaintDropPattern(50, new Colour(0, 0, 255));

            Assert.AreEqual(2, surface.Drops.Count, "Two paint drops should be added to the surface.");
            Assert.AreEqual(surface.Drops[0].Circle.Center, surface.Drops[1].Circle.Center, "The pattern should restart after reset.");
        }


    }
}