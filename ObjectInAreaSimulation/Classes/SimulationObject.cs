using ObjectInAreaSimulation.Classes.Interfaces;
using ObjectInAreaSimulation.Classes.Models;
using ObjectInAreaSimulation.Enums;

namespace ObjectInAreaSimulation.Classes
{
    public class SimulationObject() : ISimulationObject
    {
        public Coordinates Coordinates { get; set; }
        public Direction Direction { get; set; }
        public decimal StepDistance { get; set; }

        public void MoveForward() => Move(StepDistance);
        public void MoveBackwards() => Move(-StepDistance);
        public void Rotate(bool clockwise = true)
        {
            Direction = Direction switch
            {
                Direction.North => clockwise ? Direction.East : Direction.West,
                Direction.East => clockwise ? Direction.South : Direction.North,
                Direction.South => clockwise ? Direction.West : Direction.East,
                Direction.West => clockwise ? Direction.North : Direction.South,
                _ => throw new InvalidOperationException("Invalid direction")
            };
        }

        private void Move(decimal distance)
        {
            var x = Coordinates.X;
            var y = Coordinates.Y;
            Coordinates = Direction switch
            {
                Direction.North => new Coordinates(x, y - distance),
                Direction.East => new Coordinates(x + distance, y),
                Direction.South => new Coordinates(x, y + distance),
                Direction.West => new Coordinates(x - distance, y),
                _ => throw new InvalidOperationException("Invalid direction")
            };
        }
    }
}
