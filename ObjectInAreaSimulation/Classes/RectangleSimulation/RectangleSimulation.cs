using ObjectInAreaSimulation.Classes.Interfaces;
using ObjectInAreaSimulation.Classes.Models;
using ObjectInAreaSimulation.Enums;
using ObjectInAreaSimulation.Services;

namespace ObjectInAreaSimulation.Classes.RectangleSimulation
{
    public class RectangleSimulation(SimulationSettings settings, IConsoleService consoleService, ISimulationLogger logger, ISimulationObject simObject, ISimulationArea area) : ISimulation
    {
        public RectangleSimulation(SimulationSettings settings) : this(settings, new ConsoleService(), new SimulationLogger(settings), new SimulationObject(), new RectangleArea())
        { }

        private SimulationState State { get; set; }

        public void Initialize()
        {
            const int requiredInputLength = 4;
            var input = consoleService.PromptForDecimalList(InitializationPromptMessages, requiredInputLength);

            var areaBoundaries = input.Take(2).ToArray();
            area.Initialize(areaBoundaries, settings.StepDistance);
            simObject.Coordinates = new Coordinates(input.Skip(2).ToArray());
            simObject.StepDistance = settings.StepDistance;

            Initiated();
        }

        public void Run()
        {
            Start();
            consoleService.DisplayMessages(CommandPromptMessages);
            try
            {
                consoleService.ReadStreamAndExecuteCommand(this, logger, settings.ContinueSimulationOnInvalidInput);
            }
            catch (Exception ex)
            {
                Abort();
                logger.LogError(ex, $"An error occured: {ex.Message}");
            }
        }

        public void FinalizeResult()
        {
            if (State == SimulationState.Aborted)
            {
                return;
            }

            var result = new SimulationResult()
            {
                IsSuccessful = area.IsCoordinatesInside(simObject.Coordinates),
                FinalCoordinates = simObject.Coordinates
            };

            consoleService.DisplayMessage(result.ToString());
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

        public SimulationState ExecuteCommand(int commandInput)
        {
            var command = ValidateCommand(commandInput);

            switch (command)
            {
                case Commands.Exit:
                    End();
                    break;
                case Commands.MoveForward:
                    simObject.MoveForward();
                    break;
                case Commands.MoveBackwards:
                    simObject.MoveBackwards();
                    break;
                case Commands.RotateClockwise:
                    simObject.Rotate();
                    break;
                case Commands.RotateCounterClockwise:
                    simObject.Rotate(clockwise: false);
                    break;
                default:
                    throw new ArgumentException($"Invalid command: {command}");
            }

            logger.LogCommand(command, $"state: {State}, direction: {simObject.Direction}, coordinates: {simObject.Coordinates.ToString()}");
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
            logger.LogState(State);
        }

        private void End()
        {
            State = SimulationState.Ended;
            logger.LogState(State);
        }

        private void Abort()
        {
            State = SimulationState.Aborted;
            logger.LogState(State);
        }

    }
}
