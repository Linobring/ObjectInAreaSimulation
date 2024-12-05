using ConsoleApp.Classes;
using ConsoleApp.Enums;

namespace TestProject1
{
    [TestFixture]
    public class SimulationObjectTest
    {
        //private SimulationObject CreateSimObj(decimal x = 0M, decimal y = 0M, Direction direction = Direction.North)
        //{
        //    var settings = new SimulationSettings()
        //    {
        //        InitX = x,
        //        InitY = y
        //    };
        //    var simObj = new SimulationObject
        //    {
        //        Direction = direction
        //    };
        //    return simObj;
        //}

        //[Test]
        //public void TestCorrectInitialDirection()
        //{
        //    var settings = new SimulationSettings()
        //    {
        //        InitX = 0M,
        //        InitY = 0M
        //    };
        //    // Arrange & Act
        //    var simObj = new SimulationObject();
        //    // Assert
        //    Assert.AreEqual(simObj.Direction, Direction.North);
        //}

        //[TestCase(Direction.North, Direction.East),
        // TestCase(Direction.East, Direction.South),
        // TestCase(Direction.South, Direction.West),
        // TestCase(Direction.West, Direction.North),
        //]

        //public void TestRotateClockwise(Direction initDir, Direction expectedDirection)
        //{
        //    // Arrange
        //    var simObj = CreateSimObj(direction: initDir);
        //    // Act
        //    simObj.Rotate();
        //    // Assert
        //    Assert.AreEqual(simObj.Direction, expectedDirection);
        //}

        //[
        //    TestCase(Direction.North, Direction.West),
        //    TestCase(Direction.East, Direction.North),
        //    TestCase(Direction.South, Direction.East),
        //    TestCase(Direction.West, Direction.South),
        //]

        //public void TestRotateCounterClockwise(Direction initDir, Direction expectedDirection)
        //{
        //    // Arrange
        //    var simObj = CreateSimObj(direction: initDir);
        //    // Act
        //    simObj.Rotate(clockwise: false);
        //    // Assert
        //    Assert.AreEqual(simObj.Direction, expectedDirection);
        //}


        //[
        //    TestCase(Direction.North, 0, 0, 0, 1),
        //    TestCase(Direction.East, 0, 0, -1, 0),
        //    TestCase(Direction.South, 0, 0, 0, -1),
        //    TestCase(Direction.West, 0, 0, 1, 0),
        //    TestCase(Direction.North, 0, 0, 0, 0),
        //    TestCase(Direction.East, 0, 0, 0, 0),
        //    TestCase(Direction.South, 0, 0, 0, 0),
        //    TestCase(Direction.West, 0, 0, 0, 0)
        //]

        //public void TestMoveForward(Direction direction, decimal initX, decimal initY, decimal expectedX, decimal expectedY)
        //{
        //    // Arrange
        //    var simObj = CreateSimObj(x: initX, y: initY, direction: direction);
        //    // Act
        //    simObj.MoveForward();
        //    // Assert
        //    Assert.AreEqual(simObj.Coordinates, expectedX.);
        //    Assert.AreEqual(simObj.Y, expectedY);
        //}

        //[
        //    TestCase(Direction.North, 0, 0,0, 1),
        //    TestCase(Direction.East, 0, 0,  -1, 0),
        //    TestCase(Direction.South, 0, 0, 0, -1),
        //    TestCase(Direction.West, 0, 0, 1, 0),
        //    TestCase(Direction.North, 0, 0, 0, 0 ),
        //    TestCase(Direction.East, 0, 0, 0,  0),
        //    TestCase(Direction.South, 0, 0,  0, 0),
        //    TestCase(Direction.West, 0,  0, 0, 0)
        //    ]
        //public void TestMoveBackwards(Direction direction, decimal initX, decimal initY, decimal expectedX, decimal expectedY)
        //{
        //    // Arrange
        //    var simObj = CreateSimObj(x: initX, y: initY, direction: direction);
        //    // Act
        //    simObj.MoveBackwards();
        //    // Assert
        //    Assert.AreEqual(simObj.X, expectedX);
        //    Assert.AreEqual(simObj.Y, expectedY);
        //}



    }

}