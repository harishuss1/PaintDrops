using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ShapeLibraryTests")]

namespace ShapeLibrary
{
    internal class Rectangle : IRectangle
    {

        public float X { get; }
        public float Y { get; }
        public float Width { get; }
        public float Height { get; }
        public Colour Colour { get; }



        private Vector[]? _vertices;

        public Vector[] Vertices
        {
            get
            {
                if (_vertices == null)
                {
                    _vertices = new Vector[4];
                    _vertices[0] = new Vector(X, Y);
                    _vertices[1] = new Vector(X + Width, Y); 
                    _vertices[2] = new Vector(X + Width, Y + Height); 
                    _vertices[3] = new Vector(X, Y + Height); 
                }
                return _vertices;
            }
        }

        public Rectangle(float x, float y, float width, float height, Colour colour)
        {

            if (width <= 0 || height <= 0)
                throw new ArgumentException("Negative values for height and width");
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Colour = colour;
        }

        public bool Intersect(IRectangle rectangle)
        {
            Vector thisTopLeft = Vertices[0];
            Vector thisBottomRight = Vertices[2];

            Vector otherTopLeft = rectangle.Vertices[0];
            Vector otherBottomRight = rectangle.Vertices[2];

            float resultRectangleTopLeftX = Math.Max(thisTopLeft.X, otherTopLeft.X);
            float resultRectangleTopLeftY = Math.Max(thisTopLeft.Y, otherTopLeft.Y);
            Vector resultRectangleTopLeft = new Vector(resultRectangleTopLeftX, resultRectangleTopLeftY);

            float resultRectangleBottomRightX = Math.Min(thisBottomRight.X, otherBottomRight.X);
            float resultRectangleBottomRightY = Math.Min(thisBottomRight.Y, otherBottomRight.Y);
            Vector resultRectangleBottomRight = new Vector(resultRectangleBottomRightX, resultRectangleBottomRightY);

            bool intersects = resultRectangleTopLeft.X < resultRectangleBottomRight.X && resultRectangleTopLeft.Y < resultRectangleBottomRight.Y;

            return intersects;
        }


    }
}
