using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("PaintDropSimulationTests")]

namespace PaintDropSimulation
{
    internal class PaintDrop : IPaintDrop
    {
        public ICircle Circle {  get;}

        public PaintDrop(ICircle circle)
        {
            if (circle == null)
            {
                throw new ArgumentNullException("circle is null");
            }

            Circle = circle;
        }

        public void Marble(IPaintDrop other)
        {
            if (other == null)
            {
                throw new ArgumentException("Other paint drop cannot be null");
            }

            Vector otherCenter = other.Circle.Center;
            float otherRadius = other.Circle.Radius;

            for (int i = 0; i < Circle.Vertices.Length; i++)
            {
                Vector currentVertex = Circle.Vertices[i];
                Vector differenceVector = currentVertex - otherCenter;

                float magnitudeSquared = (float)(Math.Pow(differenceVector.X, 2) + Math.Pow(differenceVector.Y, 2));

                if (magnitudeSquared > 0)
                {
                    float scalingFactor = (float)Math.Sqrt(1 + Math.Pow(otherRadius, 2) / magnitudeSquared);
                    Vector newVertexPosition = otherCenter + differenceVector * scalingFactor;

                    Circle.Vertices[i] = newVertexPosition;
                }
            }
        }
        }
}

