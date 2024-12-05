using ObjectInAreaSimulation.Classes.Models;

namespace ObjectInAreaSimulation.Classes.Interfaces
{
    internal interface ISimulationArea
    {
        public decimal AnchorPointX { get; set; }
        public decimal AnchorPointY { get; set; }
        /// <summary>
        /// Validates if coordinates is inside the area.
        /// Coordinates are considered to be inside if they intersect with any coordinates inside the area
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        bool IsCoordinatesInside(Coordinates coordinates);
        /// <summary>
        /// Initializes area and ensures that boundaries and shape is correct 
        /// </summary>
        /// <param name="input"></param>
        void Initialize(decimal[] input, decimal stepDistance);
    }
}
