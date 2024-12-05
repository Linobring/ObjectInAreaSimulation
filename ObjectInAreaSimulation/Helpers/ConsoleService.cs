using System.Text;
using ObjectInAreaSimulation.Classes.Interfaces;
using ObjectInAreaSimulation.Enums;

namespace ObjectInAreaSimulation.Helpers
{
    public class ConsoleService : IConsoleService
    {
        private static readonly char[] Separators = [' ', '\t'];

        public List<decimal> PromptForDecimalList(string[] messages, int requiredLength)
        {
            while (true)
            {
                DisplayMessages(messages);
                var input = Console.ReadLine();
                var result = new List<decimal>();
                try
                {
                    result = ParseInput(input, TryParseDecimal);
                }
                catch (Exception ex)
                {
                    //TODO LogERROR
                    DisplayMessage($"Invalid input. {ex.Message}");
                    continue;
                }
                if (result.Count != requiredLength)
                {
                    DisplayMessage($"Invalid input. {requiredLength} parameters are required.");
                    continue;
                }

                return result;
            }
        }

        public void DisplayMessages(string[] messages)
        {
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);

        }

        //TODO change name
        public void ReadStreamAndExecuteCommand(ISimulation simulation, ISimulationLogger logger, bool continueOnError)
        {
            using var inputStream = Console.OpenStandardInput();
            using var reader = new StreamReader(inputStream, Encoding.UTF8);
            while (reader.ReadLine() is { } input)
            {
                try
                {
                    var commands = ParseInput(input, TryParseInt);
                    foreach (var command in commands)
                    {
                        var state = simulation.ExecuteCommand(command);
                        if (state == SimulationState.Ended)
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex);
                    if (!continueOnError)
                    {
                        throw;
                    }
                }


            }
        }

        private static List<T> ParseInput<T>(string? input, Func<string, (bool, T)> tryParse)
        {
            var result = new List<T>();
            if (string.IsNullOrWhiteSpace(input))
            {
                return result;
            }

            var inputSegments = input.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var segment in inputSegments)
            {
                var (canParse, output) = tryParse(segment);
                if (!canParse)
                {
                    throw new InvalidCastException($"Invalid integer input: {segment}.");
                }

                result.Add(output);
            }

            return result;
        }


        private static (bool, int) TryParseInt(string input)
        {
            var canParse = int.TryParse(input, out var value);
            return (canParse, value);
        }

        private static (bool, decimal) TryParseDecimal(string input)
        {
            var canParse = decimal.TryParse(input, out var value);
            return (canParse, value);
        }

    }
}
