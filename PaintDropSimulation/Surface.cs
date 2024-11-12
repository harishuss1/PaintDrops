using System;
using System.Collections.Generic;
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

        public Surface(int width, int height)
        {
            if (width < 0 || height < 0)
            {
                throw new ArgumentException("Height Or Width Cannot be null");
            }
            Width = width;
            Height = height;
            Drops = new List<IPaintDrop>();
        }

        public void AddPaintDrop(IPaintDrop drop)
        {
            if (drop == null)
            {
                throw (new ArgumentNullException());
            }
            Drops.Add(drop);

            foreach (var existingDrop in Drops)
            {
                if (existingDrop != drop)
                {
                    existingDrop.Marble(drop);
                }
            }
        }

        public void GeneratePaintDropPattern(float radius, Colour colour)
        {
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
