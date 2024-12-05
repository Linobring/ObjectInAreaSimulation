namespace ObjectInAreaSimulation.Classes.Models
{
    internal class SimulationResult
    {
        public bool IsSuccessful { get; set; }

        public Coordinates FinalCoordinates { get; set; }

        public override string ToString() =>
            IsSuccessful ? FinalCoordinates.ToString() : new Coordinates(-1, -1).ToString();
    }

}
