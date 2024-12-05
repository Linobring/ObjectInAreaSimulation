namespace ObjectInAreaSimulation.Classes.Models
{
    public class SimulationSettings
    {
        public bool ContinueSimulationOnInvalidInput { get; set; } = true;
        public bool EndIfObjectIsOutsideArea { get; set; }
        public bool LogCommands { get; set; }
    }
}
