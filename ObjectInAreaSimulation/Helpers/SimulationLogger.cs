using ObjectInAreaSimulation.Classes.Interfaces;
using ObjectInAreaSimulation.Enums;

namespace ObjectInAreaSimulation.Helpers
{
    internal class SimulationLogger(bool logCommands) : ISimulationLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
        
        public void LogCommand(Commands command, string message)
        {
            if (!logCommands)
            {
                return;
            }
            Console.WriteLine($"{command.ToString()} => {message}");
        }

        public void LogError(Exception ex, string message)
        {
            Console.WriteLine($"Error: {message}");
            Console.WriteLine($"Exception: {ex.Message}");
        }

    }
}
