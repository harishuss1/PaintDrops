using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;
using PaintDropSimulation;

namespace PatternGenerationLib
{
    public class PhyllotaxisPatternGeneration : IPatternGenerator
    {
        private double GoldenAngle = 137.5 * Math.PI / 180; 
        private float _scalingFactor;
        public int _currentPointIndex;

        public PhyllotaxisPatternGeneration(float scalingFactor)
        {
            _scalingFactor = scalingFactor;
            _currentPointIndex = 0;
        }

        public Vector? CalculatePatternPoint(ISurface surface)
        {
            if (surface == null)
            {
                throw new ArgumentNullException("Surface cannot be null");
            }

            double radius = _scalingFactor * Math.Sqrt(_currentPointIndex);
            double theta = _currentPointIndex * GoldenAngle;

            float x = (float)(radius * Math.Cos(theta)) + surface.Width / 2;
            float y = (float)(radius * Math.Sin(theta)) + surface.Height / 2;

            _currentPointIndex++;

            return new Vector(x, y);
        }
    }
}
