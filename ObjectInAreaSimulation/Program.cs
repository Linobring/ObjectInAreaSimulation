using ObjectInAreaSimulation.Classes.Models;
using ObjectInAreaSimulation.Classes.RectangleSimulation;
using static ObjectInAreaSimulation.Helpers.ConsoleHelper;

namespace ObjectInAreaSimulation
{
    public class Program
    {
        private static void Main(string[] arg)
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
    }

}




