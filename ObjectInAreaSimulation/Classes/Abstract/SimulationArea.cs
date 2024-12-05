using ObjectInAreaSimulation.Classes.Interfaces;
using ObjectInAreaSimulation.Classes.Models;

namespace ObjectInAreaSimulation.Classes.Abstract
{
    public abstract class SimulationArea : ISimulationArea
    {
        public decimal AnchorPointX { get; set; }
        public decimal AnchorPointY { get; set; }

        public abstract void Initialize(decimal[] input);

        public abstract bool IsCoordinatesInside(Coordinates coordinates);

    }
}
