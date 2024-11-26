using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;

[assembly: InternalsVisibleTo("PaintDropSimulationTests")]

namespace PaintDropSimulation
{
    internal class Surface : ISurface
    {
        public int Width { get; }
        public int Height { get; }
        public List<IPaintDrop> Drops { get; }

        public event CalculatePatternPoint? PatternGeneration;

        public IRectangle BorderSurface { get; }
        public Surface(int width, int height)
        {
            if (width < 0 || height < 0)
            {
                throw new ArgumentException("Height Or Width Cannot be null");
            }
            Width = width;
            Height = height;
            Drops = new List<IPaintDrop>();
            BorderSurface =  ShapesFactory.CreateRectangle(0, 0, width, height, new Colour(255,0,0));

        }
        public void AddPaintDrop(IPaintDrop drop)
        {
            if (drop == null)
            {
                throw (new ArgumentNullException());
            }

            if (BorderSurface.Intersect(drop.BoundingBox))
            {
                Drops.Add(drop);

                foreach (var existingDrop in Drops)
                {
                    if (existingDrop != drop)
                    {
                        existingDrop.Marble(drop);
                    }
                }
            }

            Drops.RemoveAll(d => !BorderSurface.Intersect(d.BoundingBox));
        }

        public void GeneratePaintDropPattern(float radius, Colour colour)
        {

            if (PatternGeneration == null)
            {
                throw new InvalidOperationException("event is null.");
            }

            Vector? position = PatternGeneration?.Invoke(this);

            if (position.HasValue)
            {
                ICircle circle = ShapesFactory.CreateCircle(position.Value.X, position.Value.Y, radius, colour);

                IPaintDrop newDrop = PaintDropSimulationFactory.CreatePaintDrop(circle);
                AddPaintDrop(newDrop);  
            }
        }
    }
}
