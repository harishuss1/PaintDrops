using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;
using PaintDropSimulation;

namespace PatternGenerationLib
{
    internal class SpiroPatternGeneration : IPatternGenerator
    {
        private float _radius;
        private float _frequency;
        private float _t;

        public SpiroPatternGeneration(float radius, float frequency)
        {
            _radius = radius;
            _frequency = frequency;
            _t = 0;
        }

        public Vector? CalculatePatternPoint(ISurface surface)
        {
            if (surface == null)
            {
                throw new ArgumentNullException("Surface cannot be null");
            }

            _t += 0.05f;

            float x = _radius * (float)Math.Cos(_frequency * _t) * (float)Math.Cos(_t);
            float y = _radius * (float)Math.Cos(_frequency * _t) * (float)Math.Sin(_t);

            float centerX = surface.Width / 2;
            float centerY = surface.Height / 2;

            return new Vector(centerX + x, centerY + y);
        }
    }
}