using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDropSimulation
{
    internal class Surface : ISurface
    {
        public int Width { get; }
        public int Height { get; }
        public List<IPaintDrop> Drops { get; }

        public Surface(int width, int height)
        {
            Width = width;
            Height = height;
            Drops = new List<IPaintDrop>();
        }

        public void AddPaintDrop(IPaintDrop drop)
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
    }
}



