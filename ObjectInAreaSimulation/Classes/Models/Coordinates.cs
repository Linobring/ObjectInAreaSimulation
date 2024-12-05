namespace ObjectInAreaSimulation.Classes.Models
{
    public struct Coordinates(decimal x, decimal y)
    {
        public Coordinates() : this(0, 0) { }
        public Coordinates(decimal[] array) : this(array[0], array[1]) { }

        public decimal X { get; set; } = x;
        public decimal Y { get; set; } = y;

        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
    }
}
