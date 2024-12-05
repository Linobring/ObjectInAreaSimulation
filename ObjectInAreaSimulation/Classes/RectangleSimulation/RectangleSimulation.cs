using ObjectInAreaSimulation.Classes.Interfaces;
using ObjectInAreaSimulation.Classes.Models;
using ObjectInAreaSimulation.Enums;
using static ObjectInAreaSimulation.Helpers.ConsoleHelper;

namespace ObjectInAreaSimulation.Classes.RectangleSimulation
{
    internal class RectangleSimulation(SimulationSettings settings) : ISimulation
    {
        private SimulationState State { get; set; }
        private ISimulationArea Area { get; set; } = new RectangleArea();
        private ISimulationObject SimObject { get; set; } = new SimulationObject();

        public void Initialize()
        {
            const int requiredInputLength = 4;
            var input = PromptForDecimalList(InitializationPromptMessages, requiredInputLength);

            var areaBoundaries = input.Take(2).ToArray();
            Area.Initialize(areaBoundaries, settings.StepDistance);
            SimObject.Coordinates = new Coordinates(input.Skip(2).ToArray());
            SimObject.StepDistance = settings.StepDistance;

            Initiated();
        }

        public void Run()
        {
            Start();
            DisplayMessages(CommandPromptMessages);
            try
            {
                ReadStreamAndExecuteCommand(this, settings.ContinueSimulationOnInvalidInput);
            }
            catch (Exception ex)
            {
                Abort();
                DisplayMessage($"An error occured: {ex.Message}");
            }
        }

        public void FinalizeResult()
        {
            if (State == SimulationState.Aborted)
            {
                return;
            }

            var isSuccessful = Area.IsCoordinatesInside(SimObject.Coordinates);
            var result = isSuccessful ? "successful" : "unsuccessful";
            var finalCoordinates = isSuccessful ?
                SimObject.Coordinates.ToString()
                : new Coordinates(-1, -1).ToString();

            var v = new SimulationResult();

            DisplayMessage($"RectangleSimulation was {result}. " + $"Final coordinates of the object are {finalCoordinates}");
        }


        private static string[] InitializationPromptMessages => [
            "Initializing object on Rectangle Simulation.",
            "Please provide required input: [width] [height] [startX] [startY]",
            "\twidth (integer): Defined as number of steps (coordinates) starting from 0 on the x axis",
            "\theight (integer): Defined as number of steps (coordinates) starting from 0 on the y axis",
            "\tstartX (integer): Defined as objects starting point on the x axis",
            "\tstartY (integer): Defined as objects starting point on the y axis"
        ];
        private static string[] CommandPromptMessages => [
            "\nInput one ore more commands as integers. Following commands are available:",
            "\t0 = End Simulation and print result",
            "\t1 = Move forward one step",
            "\t2 = Move backwards one step",
            "\t3 = Rotate clockwise 90 degrees (eg north to east)",
            "\t4 = Rotate counter-clockwise 90 degrees (eg west to south)",
            "\nSimulation conditions",
            "- If multiple commands are provided, any command followed by '0' will be ignored",
            "- Invalid Commands will be ignored and the simulation will proceed to the next command"
        ];

        //Execute commands
        public SimulationState ExecuteCommand(int commandInput)
        {
            var command = ValidateCommand(commandInput);

            switch (command)
            {
                case Commands.Exit:

                    End();
                    break;
                case Commands.MoveForward:
                    SimObject.MoveForward();
                    break;
                case Commands.MoveBackwards:
                    SimObject.MoveBackwards();
                    break;
                case Commands.RotateClockwise:
                    SimObject.Rotate();
                    break;
                case Commands.RotateCounterClockwise:
                    SimObject.Rotate(clockwise: false);
                    break;
                default:
                    throw new ArgumentException($"Invalid command: {command}");
            }

            return State;
        }
        private static Commands ValidateCommand(int commandInput)
        {
            var command = (Commands)commandInput;
            if (!Enum.IsDefined(command))
            {
                throw new InvalidCastException($"Failed to parse command '{commandInput}'");
            }
            return command;
        }

        private void Initiated()
        {
            State = SimulationState.Initiated;
        }

        private void Start()
        {
            State = SimulationState.Running;
            Console.WriteLine("Rectangle Simulation started");
        }

        private void End()
        {
            State = SimulationState.Ended;
            Console.WriteLine("Rectangle Simulation Ended");
        }

        private void Abort()
        {
            State = SimulationState.Aborted;
            Console.WriteLine("Rectangle Simulation Aborted");
        }

    }
}
