using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaintDropSimulation;
using PatternGenerationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;

namespace PatternGenerationLib.Tests
{
    [TestClass]
    public class SpiroPatternGenerationTests
    {
        [TestMethod]
        public void Constructor_ValidParameters_ShouldInitializeCorrectly()
        {
            float radius = 100f;
            float frequency = 2f;

            var spiroPattern = new SpiroPatternGeneration(radius, frequency);

            Assert.IsNotNull(spiroPattern);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculatePatternPoint_NullSurface_ShouldThrowArgumentNullException()
        {
            float radius = 100f;
            float frequency = 2f;
            var spiroPattern = new SpiroPatternGeneration(radius, frequency);

            spiroPattern.CalculatePatternPoint(null);

        }

        [TestMethod]
        public void CalculatePatternPoint_ValidSurface_ShouldReturnValidVector()
        {
            float radius = 100f;
            float frequency = 2f;
            var spiroPattern = new SpiroPatternGeneration(radius, frequency);
            var surface = PaintDropSimulationFactory.CreateSurface(200, 200);

            Vector? result = spiroPattern.CalculatePatternPoint(surface);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value.X >= 0 && result.Value.Y >= 0);
        }

        [TestMethod]
        public void CalculatePatternPoint_MultipleCalls_ShouldReturnDifferentValues()
        {
            float radius = 100f;
            float frequency = 2f;
            var spiroPattern = new SpiroPatternGeneration(radius, frequency);
            var surface = PaintDropSimulationFactory.CreateSurface(200, 200);

            Vector? firstPoint = spiroPattern.CalculatePatternPoint(surface);
            Vector? secondPoint = spiroPattern.CalculatePatternPoint(surface);

            Assert.IsNotNull(firstPoint);
            Assert.IsNotNull(secondPoint);
            Assert.AreNotEqual(firstPoint, secondPoint, "The pattern points should differ for consecutive calls.");
        }

        [TestMethod]
        public void CalculatePatternPoint_VerifyValuesForGivenParameters()
        {
            float radius = 100f;
            float frequency = 2f;
            var spiroPattern = new SpiroPatternGeneration(radius, frequency);
            var surface = PaintDropSimulationFactory.CreateSurface(200, 200);

            Vector? result = spiroPattern.CalculatePatternPoint(surface);

            Assert.IsNotNull(result);
            float centerX = surface.Width / 2;
            float centerY = surface.Height / 2;
            float x = radius * (float)Math.Cos(frequency * 0.05f) * (float)Math.Cos(0.05f) + centerX;
            float y = radius * (float)Math.Cos(frequency * 0.05f) * (float)Math.Sin(0.05f) + centerY;

            Assert.AreEqual(x, result.Value.X, 0.01, "X coordinate is incorrect.");
            Assert.AreEqual(y, result.Value.Y, 0.01, "Y coordinate is incorrect.");
        }
    }
}