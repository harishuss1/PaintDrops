using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternGenerationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDropSimulation;
using ShapeLibrary;

namespace PatternGenerationLib.Tests
{
    [TestClass()]
    public class PhyllotaxisPatternGenerationTests
    {
        [TestMethod]
        public void CalculatePatternPoint_ShouldReturnCorrectPosition()
        {
            var surface = PaintDropSimulationFactory.CreateSurface(640, 480);
            var patternGenerator = new PhyllotaxisPatternGeneration(10);

            var point = patternGenerator.CalculatePatternPoint(surface);

            Assert.IsNotNull(point, "Point should not be null");
            Assert.IsTrue(point.Value.X >= 0 && point.Value.Y >= 0, "Point should be within surface borders.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculatePatternPoint_NullSurface_ShouldThrowException()
        {
            var patternGenerator = new PhyllotaxisPatternGeneration(10);

            patternGenerator.CalculatePatternPoint(null);
        }

        [TestMethod]
        public void CalculatePatternPoint_ShouldReturnValidPoint()
        {
            var surface = PaintDropSimulationFactory.CreateSurface(640, 480);
            var patternGenerator = new PhyllotaxisPatternGeneration(5);

            var point = patternGenerator.CalculatePatternPoint(surface);

            Assert.IsNotNull(point, "Point should not be null");
            Assert.IsTrue(point.Value.X >= 0 && point.Value.X <= surface.Width, "X coordinate should be within surface borders.");
            Assert.IsTrue(point.Value.Y >= 0 && point.Value.Y <= surface.Height, "Y coordinate should be within surface borders.");
        }
    }
}