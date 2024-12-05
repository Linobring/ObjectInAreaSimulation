using System.Text;
using ObjectInAreaSimulation.Classes.Interfaces;
using ObjectInAreaSimulation.Enums;

namespace ObjectInAreaSimulation.Helpers
{
    internal static class ConsoleHelper
    {
        private static readonly char[] Separators = [' ', '\t'];

        /// <summary>
        /// Prompt user for input. If the input is invalid, the user will be prompted again.
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="requiredLength"></param>
        /// <returns></returns>
        public static List<decimal> PromptForDecimalList(string[] messages, int requiredLength)
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

        /// <summary>
        /// prompt user for input based on message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exit"></param>
        /// <returns>true if input equals input (case-insensitive) else false </returns>
        public static bool PromptForExit(string message, string exit = "exit")
        {
            DisplayMessage(message);
            var input = Console.ReadLine();
            return !string.IsNullOrWhiteSpace(input) && input.Equals(exit, StringComparison.InvariantCultureIgnoreCase);
        }

        public static void DisplayMessages(string[] messages)
        {
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);

        }

        //TODO change name
        public static void ReadStreamAndExecuteCommand(ISimulation simulation, bool continueOnError)
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
                catch (Exception)
                {
                    //TODO LogERROR
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
