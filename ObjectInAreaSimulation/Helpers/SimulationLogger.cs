using ObjectInAreaSimulation.Classes.Interfaces;
using ObjectInAreaSimulation.Classes.Models;
using ObjectInAreaSimulation.Enums;

namespace ObjectInAreaSimulation.Helpers
{
    public class SimulationLogger(SimulationSettings settings) : ISimulationLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
        
        public void LogCommand(Commands command, string message)
        {
            if (!settings.LogCommands)
            {
                return;
            }
            Console.WriteLine($"\t Command: {command.ToString()}, {message}");
        }

        public void LogError(Exception ex, string message = "")
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                message = ex.Message;
            }
            Log(message);
        }

    }
}
