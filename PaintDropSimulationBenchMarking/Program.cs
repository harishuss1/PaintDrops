using System;
using System.Diagnostics;
using PaintDropSimulation;
using ShapeLibrary;

class PaintDropSimulationBenchmarking
{
    static void Main(string[] args)
    {
        Console.WriteLine("PaintDropSimulation Benchmarking...");

        var surfaceSizes = new[] { 100, 500, 1000, 2000 }; 
        var numberOfDropsArray = new[] { 10, 50, 100, 200 }; 

        foreach (var size in surfaceSizes)
        {
            foreach (var numDrops in numberOfDropsArray)
            {
                BenchmarkSurface(size, size, numDrops);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private static void BenchmarkSurface(int width, int height, int numDrops)
    {
        Console.WriteLine($"Benchmarking Surface ({width}x{height}) with {numDrops} drops...");

        var stopwatch = new Stopwatch();

        var surface = PaintDropSimulationFactory.CreateSurface(width, height);

        stopwatch.Start();

        var random = new Random();
        for (int i = 0; i < numDrops; i++)
        {
            var x = random.Next(0, width);
            var y = random.Next(0, height);
            var radius = random.Next(10, 50);
            var color = new Colour(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
            var circle = ShapesFactory.CreateCircle(x, y, radius, color);

            var drop = PaintDropSimulationFactory.CreatePaintDrop(circle);
            surface.AddPaintDrop(drop);
        }

        stopwatch.Stop();

        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
    }
}
