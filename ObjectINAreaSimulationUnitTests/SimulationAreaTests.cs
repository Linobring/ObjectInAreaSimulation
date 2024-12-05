using ObjectInAreaSimulation.Classes.Models;
using ObjectInAreaSimulation.Classes.RectangleSimulation;

namespace ObjectInAreaSimulationUnitTests
{
    [TestFixture]
    public class SimulationAreaTest
    {

        // test for rectangle 
        //general test for rectangle

        #region RectangleArea error tests 

        [
            TestCase(1,0),
            TestCase(0,1)
        ]
        public void TestInitialize_RectangleArea_ArgumentException_01(decimal w, decimal h)
        {
            // Arrange
            var input = new []{w,h};
            var area = new RectangleArea();
            // Act & Assert
            Assert.Throws<ArgumentException>(() => area.Initialize(input, 1));
        }

        [Test]
        public void TestInitialize_RectangleArea_ArgumentException_02()
        {
            // Arrange
            decimal[]? input = null;
            var area = new RectangleArea();
            // Act & Assert
            Assert.Throws<ArgumentException>(() => area.Initialize(input, 1));
        }

        [Test]
        public void TestInitialize_RectangleArea_ArgumentException_03()
        {
            // Arrange
            var input = new[] { 1M,1M,1M};
            var area = new RectangleArea();
            // Act & Assert
            Assert.Throws<ArgumentException>(() => area.Initialize(input, 1));
        }

        [Test]
        public void TestInitialize_RectangleArea_ArgumentException_04()
        {
            // Arrange
            var input = new[] { 1M,};
            var area = new RectangleArea();
            // Act & Assert
            Assert.Throws<ArgumentException>(() => area.Initialize(input, 1));
        }

        [Test]
        public void TestInitialize_RectangleArea_ArgumentException_05()
        {
            // Arrange
            decimal[] input = [];
            var area = new RectangleArea();
            // Act & Assert
            Assert.Throws<ArgumentException>(() => area.Initialize(input, 1));
        }

        #endregion

        #region RectangleArea tests


        [
            TestCase(1,4, 4, 2, 2, true),
            TestCase(1, 4, 4, 0, 0, true),
            TestCase(1, 4, 4, 4, 4, false),
            TestCase(1, 4, 4, -1, 1, false),
            TestCase(1, 4, 4, 1, -1, false),
            TestCase(1, 4, 4, 5, 5, false),
            TestCase(1, 4, 4, 0, 4, false),
            TestCase(1, 4, 4, 2, 4, false),
            TestCase(1, 4, 4, 4, 2, false),
            TestCase(1, 4, 4, -4, -4, false),
            TestCase(1, 10, 5, 5, 2.5, true),
            TestCase(1, 10, 5, 10, 5, false),
            TestCase(0.01, 4, 4, 3.99, 3.99, true),
            TestCase(1, 4, 4, 2, 2.0001, true),
            TestCase(1, -4, -4, 2, 2, false),
            TestCase(1, -4, -4, -2, -2, false),
            TestCase(0.8, 4, 4, 1, 3.2, true),
            TestCase(0.8, 4, 4, 1, 3.3, false),


        ]
        public void TestIsCoordinatesInside_RectangleArea(decimal stepDistance, decimal w, decimal h, decimal x, decimal y, bool expectedResult)
        {
            // Arrange
            var coordinates = new Coordinates(x, y);
            var area = new RectangleArea();
            area.Initialize([w,h], stepDistance);

            // Act
            var result = area.IsCoordinatesInside(coordinates);
            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        #endregion
    }

}