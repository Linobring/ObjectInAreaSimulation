using ObjectInAreaSimulation.Classes;
using ObjectInAreaSimulation.Classes.Models;
using ObjectInAreaSimulation.Enums;

namespace ObjectInAreaSimulationUnitTests
{
    [TestFixture]
    public class SimulationObjectTest
    {
        [Test]
        public void TestDefaultDirection()
        {
            // Arrange & Act
            var simObj = new SimulationObject();
            // Assert
            Assert.That(simObj.Direction, Is.EqualTo(Direction.North));
        }

        [
            TestCase(Direction.North, Direction.East),
            TestCase(Direction.East, Direction.South),
            TestCase(Direction.South, Direction.West),
            TestCase(Direction.West, Direction.North),
        ]
        public void TestRotateClockwise(Direction initDir, Direction expectedDirection)
        {
            // Arrange
            var simObj = new SimulationObject()
            {
                Direction = initDir
            };
            // Act
            simObj.Rotate();
            // Assert
            Assert.That(simObj.Direction, Is.EqualTo(expectedDirection));
        }

        [
            TestCase(Direction.North, Direction.West),
            TestCase(Direction.East, Direction.North),
            TestCase(Direction.South, Direction.East),
            TestCase(Direction.West, Direction.South),
        ]
        public void TestRotateCounterClockwise(Direction initDir, Direction expectedDirection)
        {
            // Arrange
            var simObj = new SimulationObject()
            {
                Direction = initDir
            };
            // Act
            simObj.Rotate(clockwise: false);
            // Assert
            Assert.That(simObj.Direction, Is.EqualTo(expectedDirection));
        }


        [
            TestCase(Direction.North, 1, 0,0, 0,-1),
            TestCase(Direction.East, 1, 0, 0, 1, 0),
            TestCase(Direction.South, 1, 0, 0, 0, 1),
            TestCase(Direction.West, 1, 0, 0, -1, 0),
            
            TestCase(Direction.North, 0, 0, 0, 0, 0),
            TestCase(Direction.East, 0, 0, 0, 0, 0),
            TestCase(Direction.South, 0, 0, 0, 0, 0),
            TestCase(Direction.West, 0, 0, 0, 0, 0),

            TestCase(Direction.North, 1.34, 2.3, 2, 2.3, 0.66),
            TestCase(Direction.East, 1.34, 2.3, 2, 3.64, 2),
            TestCase(Direction.South, 1.34, 2.3, 2, 2.3, 3.34),
            TestCase(Direction.West, 1.34, 2.3, 2, 0.96, 2),
        ]
        public void TestMoveForward(Direction direction, decimal stepDistance, decimal initX, decimal initY, decimal expectedX, decimal expectedY)
        {
            // Arrange
            var expectedCoordinates = new Coordinates(expectedX, expectedY);
            var simObj = new SimulationObject()
            {
                Coordinates = new Coordinates(initX, initY),
                Direction = direction, 
                StepDistance = stepDistance,
            };

            // Act
            simObj.MoveForward();
            // Assert
            Assert.That(simObj.Coordinates, Is.EqualTo(expectedCoordinates));

        }

        [
            TestCase(Direction.North, 1, 0, 0, 0, 1),
            TestCase(Direction.East, 1, 0, 0, -1, 0),
            TestCase(Direction.South, 1, 0, 0, 0, -1),
            TestCase(Direction.West, 1, 0, 0, 1, 0),

            TestCase(Direction.North, 0, 0, 0, 0, 0),
            TestCase(Direction.East, 0, 0, 0, 0, 0),
            TestCase(Direction.South, 0, 0, 0, 0, 0),
            TestCase(Direction.West, 0, 0, 0, 0, 0),

            TestCase(Direction.North, 1.34, 2.3, 2, 2.3, 3.34),
            TestCase(Direction.South, 1.34, 2.3, 2, 2.3, 0.66),
            TestCase(Direction.West, 1.34, 2.3, 2, 3.64, 2),
            TestCase(Direction.East, 1.34, 2.3, 2, 0.96, 2),
        ]
        public void TestMoveBackwards(Direction direction, decimal stepDistance, decimal initX, decimal initY, decimal expectedX, decimal expectedY)
        {
            // Arrange
            var initCoordinates = new Coordinates(initX, initY);
            var expectedCoordinates = new Coordinates(expectedX, expectedY);
            var simObj = new SimulationObject()
            {
                Coordinates = new Coordinates(initX, initY),
                Direction = direction,
                StepDistance = stepDistance,
            };

            // Act
            simObj.MoveBackwards();
            // Assert
            Assert.That(simObj.Coordinates, Is.EqualTo(expectedCoordinates));

        }



    }

}