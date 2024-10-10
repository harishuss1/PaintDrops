using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public class ShapesFactory
    {
            public static ICircle CreateCircle(float x, float y, float radius, Colour colour)
            {
                ICircle circle = new Circle(x, y, radius, colour);
                return circle;
            }

            public static IRectangle CreateRectangle(float x, float y, float width, float height, Colour colour)
            {
                IRectangle rectangle = new Rectangle(x, y, width, height, colour);
                return rectangle;
            }
    }
}
