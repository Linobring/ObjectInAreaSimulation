using NSubstitute;
using ObjectInAreaSimulation.Classes.Interfaces;
using ObjectInAreaSimulation.Classes.Models;
using ObjectInAreaSimulation.Classes.RectangleSimulation;
using ObjectInAreaSimulation.Enums;

namespace ObjectInAreaSimulationUnitTests
{
    [TestFixture]
    public class SimulationTest
    {
        [Test]
        public void InitializeRectangleSimulation()
        {
            // Arrange
            var settings = new SimulationSettings();
            var loggerMock = Substitute.For<ISimulationLogger>();
            var simObjectMock = Substitute.For<ISimulationObject>();
            var simAreaMock = Substitute.For<ISimulationArea>();
            var consoleServiceMock = Substitute.For<IConsoleService>();

            consoleServiceMock.PromptForDecimalList(Arg.Any<string[]>(), 4).ReturnsForAnyArgs([4M, 4M, 2M, 2M]);
            
            var sut = new RectangleSimulation(settings, consoleServiceMock, loggerMock, simObjectMock, simAreaMock);

            // Act
            sut.Initialize();

            // Assert
            consoleServiceMock.Received(1).PromptForDecimalList(Arg.Any<string[]>(), 4);
            simAreaMock.Received(1).Initialize(Arg.Any<decimal[]>(), settings.StepDistance);
            Assert.That(simObjectMock.Coordinates, Is.EqualTo(new Coordinates(2,2)));
        }


        [Test]
        public void RunRectangleSimulation()
        {
            // Arrange
            var settings = new SimulationSettings();
            var loggerMock = Substitute.For<ISimulationLogger>();
            var simObjectMock = Substitute.For<ISimulationObject>();
            var simAreaMock = Substitute.For<ISimulationArea>();
            var consoleServiceMock = Substitute.For<IConsoleService>();

            var sut = new RectangleSimulation(settings, consoleServiceMock, loggerMock, simObjectMock, simAreaMock);
            
            // Act
            sut.Run();

            // Assert
            consoleServiceMock.Received(1).ReadStreamAndExecuteCommand(sut, loggerMock, settings.ContinueSimulationOnInvalidInput);
            consoleServiceMock.Received(1).DisplayMessages(Arg.Any<string[]>());
        }

        [Test]
        public void RunRectangleSimulation_Abort()
        {
            // Arrange
            var settings = new SimulationSettings();
            var loggerMock = Substitute.For<ISimulationLogger>();
            var simObjectMock = Substitute.For<ISimulationObject>();
            var simAreaMock = Substitute.For<ISimulationArea>();
            var consoleServiceMock = Substitute.For<IConsoleService>();

            var sut = new RectangleSimulation(settings, consoleServiceMock, loggerMock, simObjectMock, simAreaMock);
            consoleServiceMock
                .When(cs => cs.ReadStreamAndExecuteCommand(sut, loggerMock, settings.ContinueSimulationOnInvalidInput))
                .Do(_ => throw new Exception());
            // Act
            sut.Run();

            // Assert
            consoleServiceMock.Received(1).ReadStreamAndExecuteCommand(sut, loggerMock, settings.ContinueSimulationOnInvalidInput);
            consoleServiceMock.Received(1).DisplayMessages(Arg.Any<string[]>());
            loggerMock.Received(1).LogError(Arg.Any<Exception>(),Arg.Any<string>());
        }

        [Test]
        public void ExecuteCommandsRectangleSimulation()
        {
            // Arrange
            var settings = new SimulationSettings();
            var loggerMock = Substitute.For<ISimulationLogger>();
            var simObjectMock = Substitute.For<ISimulationObject>();
            var simAreaMock = Substitute.For<ISimulationArea>();
            var consoleServiceMock = Substitute.For<IConsoleService>();

            var sut = new RectangleSimulation(settings, consoleServiceMock, loggerMock, simObjectMock, simAreaMock);

            var commands = new[] {1, 2, 3, 4 };

            // Act
            foreach (var command in commands)
            {
                sut.ExecuteCommand(command);
            }

            // Assert
            simObjectMock.Received(1).MoveForward();
            simObjectMock.Received(1).MoveBackwards();
            simObjectMock.Received(1).Rotate();
            simObjectMock.Received(1).Rotate(clockwise: false);
            loggerMock.Received(4).LogCommand(Arg.Any<Commands>(), Arg.Any<string>());
        }

        [Test]
        public void ExecuteCommandsRectangleSimulation_InvalidInput()
        {
            // Arrange
            var settings = new SimulationSettings();
            var loggerMock = Substitute.For<ISimulationLogger>();
            var simObjectMock = Substitute.For<ISimulationObject>();
            var simAreaMock = Substitute.For<ISimulationArea>();
            var consoleServiceMock = Substitute.For<IConsoleService>();

            var sut = new RectangleSimulation(settings, consoleServiceMock, loggerMock, simObjectMock, simAreaMock);

            const int command = 22;

            // Act & assert

            var ex = Assert.Throws<InvalidCastException>(() => sut.ExecuteCommand(command));
            Assert.That(ex, Is.TypeOf<InvalidCastException>());
        }

        [Test]
        public void FinalizeResultCommandsRectangleSimulation()
        {
            // Arrange
            var settings = new SimulationSettings();
            var loggerMock = Substitute.For<ISimulationLogger>();
            var simObjectMock = Substitute.For<ISimulationObject>();
            var simAreaMock = Substitute.For<ISimulationArea>();
            var consoleServiceMock = Substitute.For<IConsoleService>();

            var sut = new RectangleSimulation(settings, consoleServiceMock, loggerMock, simObjectMock, simAreaMock);

            // Act
            sut.FinalizeResult();

            // Assert
            simAreaMock.Received(1).IsCoordinatesInside(Arg.Any<Coordinates>());
            consoleServiceMock.Received(1).DisplayMessage(Arg.Any<string>());
        }

    }

}