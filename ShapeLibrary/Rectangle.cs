using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public class Rectangle : IRectangle
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
    }
}
