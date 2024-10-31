using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("PaintDropSimulationTests")]

namespace PaintDropSimulation
{
    internal class PaintDrop : IPaintDrop
    {
        public ICircle Circle {  get;}

        public PaintDrop(ICircle circle)
        {
            if (circle == null)
            {
                throw new ArgumentNullException("circle is null");
            }

            Circle = circle;
        }

        public void Marble(IPaintDrop other)
        {
            if(other == null)
            {
                throw new ArgumentNullException("other is null ");
            }

            RecalculateVerticesForMarble(this.Circle, other.Circle);
        }

        private Vector ApplyMarbleFormula(Vector P, ICircle existingCircle, ICircle newCircle)
        {
            Vector C_existing = existingCircle.Center; 
            Vector C_new = newCircle.Center;           
            float r_new = newCircle.Radius;            

            float distanceSquared = Vector.Magnitude(P - C_new) * Vector.Magnitude(P - C_new);

            if (distanceSquared > 0) 
            {
                Vector displacement = (P - C_new) * (float)Math.Sqrt(1 + (r_new * r_new) / distanceSquared);
                return C_new + displacement;
            }
            else
            {
                return P;
            }
        }

        private void RecalculateVerticesForMarble(ICircle existingCircle, ICircle newCircle)
        {
            for (int i = 0; i < existingCircle.Vertices.Length; i++)
            {
                Vector displacedVertex = ApplyMarbleFormula(existingCircle.Vertices[i], existingCircle, newCircle);
                existingCircle.Vertices[i] = displacedVertex;
            }
        }
    }
}

