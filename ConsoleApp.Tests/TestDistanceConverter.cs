using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App01;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class TestDistanceConverter
    {
        [TestMethod]
        public void TestMilesToFeet()
        {

            // 1. Arrange
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceUnits.Miles;
            converter.ToUnit = DistanceUnits.Feet;

            converter.FromDistance = 1.0;

            // 2. Act
            converter.CalculateDistance();
            double expectedDistance = 5280;

            // 3. Assert
            Assert.AreEqual(expectedDistance, converter.ToDistance);

        }

        [TestMethod]
        public void TestFeetToMiles()
        {

            // 1. Arrange
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceUnits.Feet;
            converter.ToUnit = DistanceUnits.Miles;

            converter.FromDistance = 5280;

            // 2. Act
            converter.CalculateDistance();
            double expectedDistance = 1;

            // 3. Assert
            Assert.AreEqual(expectedDistance, converter.ToDistance);

        }

        [TestMethod]
        public void TestFeetToMetres()
        {

            // 1. Arrange
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceUnits.Feet;
            converter.ToUnit = DistanceUnits.Metres;

            converter.FromDistance = 3.28084; //TODO: ADJUST UNIT

            // 2. Act
            converter.CalculateDistance();
            double expectedDistance = 1;

            // 3. Assert
            Assert.AreEqual(expectedDistance, converter.ToDistance);

        }

        [TestMethod]
        public void TestMetresToFeet()
        {

            // 1. Arrange
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceUnits.Metres;
            converter.ToUnit = DistanceUnits.Feet;

            converter.FromDistance = 1; //TODO: ADJUST UNIT

            // 2. Act
            converter.CalculateDistance();
            double expectedDistance = 3.28084;

            // 3. Assert
            Assert.AreEqual(expectedDistance, converter.ToDistance);

        }

        [TestMethod]
        public void TestMetresToMiles()
        {

            // 1. Arrange
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceUnits.Metres;
            converter.ToUnit = DistanceUnits.Miles;

            converter.FromDistance = 1609.34; //TODO: ADJUST UNIT

            // 2. Act
            converter.CalculateDistance();
            double expectedDistance = 1;

            // 3. Assert
            Assert.AreEqual(expectedDistance, converter.ToDistance);

        }

        [TestMethod]
        public void TestMilesToMetres()
        {

            // 1. Arrange
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceUnits.Miles;
            converter.ToUnit = DistanceUnits.Metres;

            converter.FromDistance = 1; //TODO: ADJUST UNIT

            // 2. Act
            converter.CalculateDistance();
            double expectedDistance = 1609.34;

            // 3. Assert
            Assert.AreEqual(expectedDistance, converter.ToDistance);

        }
    }
}
