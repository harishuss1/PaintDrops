using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public struct Vector
    {
        public float X { get; }
        public float Y { get; }

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }
        public Vector(Vector v)
        {
            X = v.X;
            Y = v.Y;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector((a.X + b.X), (a.Y + b.Y));

        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector((-a.X - b.X), (-a.Y - b.Y));
        }

        public static Vector operator *(Vector a, float scalar)
        {
            return new Vector(a.X * scalar, a.Y * scalar);
        }

        public static Vector operator /(Vector a, float scalar)
        {
            if (scalar == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return new Vector(a.X / scalar, a.Y / scalar);
        }

        public static float Magnitude(Vector v)
        {
            return (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }

        public static Vector Normalize(Vector v)
        {
            float magnitude = Magnitude(v);
            if (magnitude == 0)
            {
                throw new InvalidOperationException("Cannot normalize a vector with magnitude of 0.");
            }
            return v / magnitude;
        }

        public override string ToString()
        {
            return $"Vector :{X},{Y}";
        }


    }
}
