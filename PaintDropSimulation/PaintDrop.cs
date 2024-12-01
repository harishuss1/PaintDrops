using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        private IRectangle ?_boundingBox;
        public IRectangle BoundingBox
        {
            get
            {
                // Fix Lazy Loading
                if (_boundingBox == null)
                {
                    UpdateBoundingBox();
                }
                return _boundingBox;
            }
        }

        public PaintDrop(ICircle circle)
        {
            if (circle == null)
            {
                throw new ArgumentNullException("circle is null");
            }

            Circle = circle;
            UpdateBoundingBox();

        }

        public void Marble(IPaintDrop other)
        {
            if (other == null)
            {
                throw new ArgumentException("Other paint drop cannot be null");
            }

            Vector otherCenter = other.Circle.Center;
            float otherRadiusSquared = other.Circle.Radius * other.Circle.Radius;

            for (int i = 0; i < Circle.Vertices.Length; i++)
            {
                Vector currentVertex = Circle.Vertices[i];
                Vector differenceVector = currentVertex - otherCenter;

                // Compute Math.Pow manually since Math.pow is performance heavy 
                float magnitudeSquared = differenceVector.X * differenceVector.X + differenceVector.Y * differenceVector.Y;

                if (magnitudeSquared > 0)
                {
                    float scalingFactor = (float)Math.Sqrt(1 + otherRadiusSquared / magnitudeSquared);
                    // Directly update vertices instead creating a variable
                    Circle.Vertices[i] = otherCenter + differenceVector * scalingFactor;

                }
            }
            UpdateBoundingBox();
        }

        private void UpdateBoundingBox()
        {
            // Intialize the min and max values
            var firstVertex = Circle.Vertices[0];
            float minX = firstVertex.X;
            float minY = firstVertex.Y;
            float maxX = firstVertex.X;
            float maxY = firstVertex.Y;

            // Iterate through the vertices to set the min and max in a single loop
            foreach (var vertex in Circle.Vertices)
            {
                if (vertex.X < minX) minX = vertex.X;
                if (vertex.Y < minY) minY = vertex.Y;
                if (vertex.X > maxX) maxX = vertex.X;
                if (vertex.Y > maxY) maxY = vertex.Y;
            }

            float width = maxX - minX;
            float height = maxY - minY;

            _boundingBox = ShapesFactory.CreateRectangle(minX, minY, width, height, new Colour(255, 0, 0));
        }

    }
}

