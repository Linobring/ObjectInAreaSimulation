using ObjectInAreaSimulation.Classes.Models;

namespace ObjectInAreaSimulation.Classes.Interfaces
{
    internal interface ISimulationArea
    {
        public decimal AnchorPointX { get; set; }
        public decimal AnchorPointY { get; set; }
        bool IsCoordinatesInside(Coordinates coordinates);
        void Initialize(decimal[] input);
    }
}
