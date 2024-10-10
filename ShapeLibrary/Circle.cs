using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapeLibrary
{
    internal class Circle : ICircle
    {
        public float Radius { get; }

        public Vector Center { get; }

        private Vector[]? _vertices;

        public Colour Colour { get; }

        public Vector[] Vertices
        {
            get
            {
                if (_vertices == null)
                {
                    int numPoints = 50;  
                    _vertices = new Vector[numPoints];
                    float angle = CalculateAngle(numPoints);

                    for (int i = 0; i < numPoints; i++)
                    {
                        float vectorX = (float)(Center.X + Radius * Math.Cos(i * angle));
                        float vectorY = (float)(Center.Y + Radius * Math.Sin(i * angle));
                        _vertices[i] = new Vector(vectorX, vectorY);
                    }
                }
                return _vertices;
            }
        }

        private float CalculateAngle(int n)
        {
            return (float)(2 * Math.PI / n);
        }

        public Circle(float x, float y, float radius, Colour colour)
        {
            if (radius < 0)
            {
                throw new ArgumentException("Radius cannot be negative.");
            }
            Radius = radius;
            Center = new Vector(x, y);
            Colour = colour;
        }
        
    }



}

