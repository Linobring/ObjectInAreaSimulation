using ObjectInAreaSimulation.Classes.Abstract;
using ObjectInAreaSimulation.Classes.Models;

namespace ObjectInAreaSimulation.Classes.RectangleSimulation
{
    public class RectangleArea() : SimulationArea
    {
        public decimal X1 { get; internal set; }
        public decimal X2 { get; internal set; }
        public decimal Y1 { get; internal set; }
        public decimal Y2 { get; internal set; }

        public override bool IsCoordinatesInside(Coordinates coordinates)
        {
            var objX = coordinates.X;
            var objY = coordinates.Y;
            return objX >= X1 && objX <= X2 && objY >= Y1 && objY <= Y2;
        }

        public override void Initialize(decimal[] input, decimal stepDistance)
        {
            if (input?.Length != 2)
            {
                throw new ArgumentException("Invalid number of arguments for initializing simulation area");
            }

            if (input.Any(d => d == 0))
            {
                throw new ArgumentException("Width or height cannot be zero");
            }

            var width = input[0];
            var height = input[1];
            X1 = AnchorPointX;
            Y1 = AnchorPointY;
            X2 = AnchorPointX + width - stepDistance;
            Y2 = AnchorPointY + height - stepDistance;
        }
    }
}
