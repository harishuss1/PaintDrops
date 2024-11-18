using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternGenerationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDropSimulation;

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
        public void Reset_ShouldRestartPatternSequence()
        {
            var surface = PaintDropSimulationFactory.CreateSurface(640, 480);
            var patternGenerator = new PhyllotaxisPatternGeneration(10);

            var point1 = patternGenerator.CalculatePatternPoint(surface);
            patternGenerator._currentPointIndex = 0;
            var point2 = patternGenerator.CalculatePatternPoint(surface);

            Assert.AreEqual(point1, point2, "the pattern should start from the beginning.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CalculatePatternPoint_NullSurface_ShouldThrowException()
        {
            var patternGenerator = new PhyllotaxisPatternGeneration(10);

            patternGenerator.CalculatePatternPoint(null);

        }
    }
}