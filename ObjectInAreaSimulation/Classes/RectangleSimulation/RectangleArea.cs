using ObjectInAreaSimulation.Classes.Abstract;
using ObjectInAreaSimulation.Classes.Models;

namespace ObjectInAreaSimulation.Classes.RectangleSimulation
{
    internal class RectangleArea() : SimulationArea
    {
        public decimal Width { get; internal set; }
        public decimal Height { get; internal set; }

        public override bool IsCoordinatesInside(Coordinates coordinates)
        {
            var x = coordinates.X;
            var y = coordinates.Y;
            return x >= AnchorPointX && x < Width && y >= AnchorPointY && y < Height;
        }

        public override void Initialize(decimal[] input)
        {
            if (input?.Length != 2)
            {
                throw new ArgumentException("Invalid number of arguments for initializing simulation area");
            }

            if (input.Any(d => d == 0))
            {
                throw new ArgumentException("Width or height cannot be zero");
            }

            Width = input[0];
            Height = input[1];
        }
    }
}
