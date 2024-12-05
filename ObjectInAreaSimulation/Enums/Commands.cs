namespace ObjectInAreaSimulation.Enums
{
    public enum Commands
    {
        /// <summary>
        /// End simulation and print results
        /// </summary>
        Exit = 0,
        /// <summary>
        /// Move forward one step
        /// </summary>
        MoveForward = 1,
        /// <summary>
        /// Move backwards one step 
        /// </summary>
        MoveBackwards = 2,
        /// <summary>
        /// rotate clockwise 90 degrees
        /// </summary>
        RotateClockwise = 3,
        /// <summary>
        /// rotate counter-clockwise 90 degrees
        /// </summary>
        RotateCounterClockwise = 4
    }
}
