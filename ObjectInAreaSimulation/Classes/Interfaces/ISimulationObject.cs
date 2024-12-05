using ObjectInAreaSimulation.Classes.Models;
using ObjectInAreaSimulation.Enums;

namespace ObjectInAreaSimulation.Classes.Interfaces
{
    public interface ISimulationObject
    { 
        public Coordinates Coordinates { get; set; }

        public Direction Direction { get; set; }
        public decimal StepDistance { get; set; }

        /// <summary>
        /// Move object Forward in the direction it is facing.
        /// </summary>
        void MoveForward();

        /// <summary>
        /// Move object backwards in the direction it is facing.
        /// </summary>
        void MoveBackwards();


        /// <summary>
        /// Rotate object 90 degrees in the specified direction.
        /// if clockwise is true, rotate clockwise, otherwise rotate counterclockwise.
        /// </summary>
        /// <param name="clockwise"></param>
        void Rotate(bool clockwise = true);
    }
}
