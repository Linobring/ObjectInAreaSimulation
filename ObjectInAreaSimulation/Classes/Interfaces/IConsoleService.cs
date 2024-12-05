namespace ObjectInAreaSimulation.Classes.Interfaces
{
    internal interface IConsoleService
    {
        /// <summary>
        /// Prompt user for input. If the input is invalid, the user will be prompted again.
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="requiredLength"></param>
        /// <returns></returns>
        List<decimal> PromptForDecimalList(string[] messages, int requiredLength);

        void DisplayMessages(string[] messages);

        void DisplayMessage(string message);

        //TODO change name
        void ReadStreamAndExecuteCommand(ISimulation simulation, ISimulationLogger logger, bool continueOnError);
    }
}
