using ObjectInAreaSimulation.Classes.Interfaces;
using ObjectInAreaSimulation.Classes.Models;
using ObjectInAreaSimulation.Classes.RectangleSimulation;

namespace ObjectInAreaSimulation
{
    public class Program
    {
        private static void Main(string[] arg)
        {
            MainProgram();
        }

        private static void MainProgram()
        {
            var settings = new SimulationSettings()
            {
                LogCommands = false,
                LogErrors = false,
                LogSimulationState = false,
            };
            var simulation = new RectangleSimulation(settings);
            simulation.Initialize();
            simulation.Run();
            simulation.FinalizeResult();
        }

        private static void PlayfulProgram()
        {
            var simulation = new RectangleSimulation(new SimulationSettings());
            var exit = false;
            while (!exit)
            {
                simulation.Initialize();
                simulation.Run();
                simulation.FinalizeResult();
                exit = PromptForExit("Press enter to run simulation again? To exit simulation type 'exit' and enter.");
            }
        }

        /// <summary>
        /// prompt user for input based on message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exit"></param>
        /// <returns>true if input equals input (case-insensitive) else false </returns>
        private static bool PromptForExit(string message, string exit = "exit")
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            return !string.IsNullOrWhiteSpace(input) && input.Equals(exit, StringComparison.InvariantCultureIgnoreCase);
        }
    }

}




