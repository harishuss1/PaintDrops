using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public struct Colour
    {
        public int Red { get; }
        public int Green { get; }
        public int Blue { get; }

        public Colour(int red, int green, int blue)
        {
            Red = ValidateColour(red);
            Green = ValidateColour(green);
            Blue = ValidateColour(blue);
        }

        private static int ValidateColour(int value)
        {
            if (value < 0) return 0;
            if (value > 255) return 255;
            return value;
        }



        public static Colour operator +(Colour c1, Colour c2)
        {
            return new Colour(
                ValidateColour(c1.Red + c2.Red),
                ValidateColour(c1.Green + c2.Green),
                ValidateColour(c1.Blue + c2.Blue)
            );
        }

        public static Colour operator -(Colour c1, Colour c2)
        {
            return new Colour(
                ValidateColour(c1.Red - c2.Red),
                ValidateColour(c1.Green - c2.Green),
                ValidateColour(c1.Blue - c2.Blue)
            );
        }

        public static Colour operator *(Colour c, int scale)
        {
            return new Colour(
                ValidateColour(c.Red * scale),
                ValidateColour(c.Green * scale),
                ValidateColour(c.Blue * scale)
            );
        }

        public static bool operator ==(Colour c1, Colour c2)
        {
            return c1.Red == c2.Red && c1.Green == c2.Green && c1.Blue == c2.Blue;
        }

        public static bool operator !=(Colour c1, Colour c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return $"Colour(Red: {Red}, Green: {Green}, Blue: {Blue})";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Colour))
                return false;

            Colour other = (Colour)obj;
            return this == other;
        }

    }
}
