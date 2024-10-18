﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLibrary;
namespace PaintDropSimulation
{
    public class PaintDropSimulationFactory
    {
        public static IPaintDrop CreatePaintDrop(ICircle circle)
        {
            IPaintDrop paintDrop = new PaintDrop(circle);
            return paintDrop;
        }

        public static ISurface CreateSurface()
        {
            ISurface surface = new Surface();
            return surface;
        }
    }
}
