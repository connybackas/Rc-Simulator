using RcSimulator.Implementation.RcCar;
using Xunit;

namespace RcSimulator.Tests
{
    /// <summary>
    /// Unit tests for testing Rc Car behavior 
    /// </summary>
    public class CarTests
    {
        [Fact]
        public void testTurnRightTwoTimesFromSouthDirection()
        {
            Car testTruck = new MonsterTruck(Heading.SOUTH, new Position(0, 0));

            testTruck.executeCommand(Command.RIGHT);
            testTruck.executeCommand(Command.RIGHT);

            Assert.Equal(Heading.NORTH, testTruck.heading);
            Assert.Equal(0, testTruck.position.X);
            Assert.Equal(0, testTruck.position.Y);
        }

        [Fact]
        public void testTurnLeftTwoTimesFromEastDirection()
        {
            Car testTruck = new MonsterTruck(Heading.EAST, new Position(0, 0));

            testTruck.executeCommand(Command.LEFT);
            testTruck.executeCommand(Command.LEFT);

            Assert.Equal(Heading.WEST, testTruck.heading);
            Assert.Equal(0, testTruck.position.X);
            Assert.Equal(0, testTruck.position.Y);
        }

        [Fact]
        public void testForwardMovement()
        {
            Car testTruck = new MonsterTruck(Heading.NORTH, new Position(0, 0));

            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.RIGHT);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.LEFT);
            testTruck.executeCommand(Command.FORWARD);

            Assert.Equal(2, testTruck.position.Y);
            Assert.Equal(2, testTruck.position.X);
        }

        [Fact]
        public void testReverseMovement()
        {
            Car testTruck = new MonsterTruck(Heading.WEST, new Position(1, 2));

            testTruck.executeCommand(Command.BACK);
            testTruck.executeCommand(Command.RIGHT);
            testTruck.executeCommand(Command.BACK);
            testTruck.executeCommand(Command.BACK);
            testTruck.executeCommand(Command.LEFT);
            testTruck.executeCommand(Command.BACK);

            Assert.Equal(3, testTruck.position.X);
            Assert.Equal(0, testTruck.position.Y);
        }

        [Fact]
        public void testDriveClockWiseSquare()
        {
            Car testTruck = new MonsterTruck(Heading.EAST, new Position(0, 0));

            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            Assert.Equal(3, testTruck.position.X);
            Assert.Equal(0, testTruck.position.Y);
            Assert.Equal(Heading.EAST, testTruck.heading);

            testTruck.executeCommand(Command.LEFT);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            Assert.Equal(3, testTruck.position.X);
            Assert.Equal(3, testTruck.position.Y);
            Assert.Equal(Heading.NORTH, testTruck.heading);

            testTruck.executeCommand(Command.LEFT);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            Assert.Equal(0, testTruck.position.X);
            Assert.Equal(3, testTruck.position.Y);
            Assert.Equal(Heading.WEST, testTruck.heading);

            testTruck.executeCommand(Command.LEFT);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            Assert.Equal(0, testTruck.position.X);
            Assert.Equal(0, testTruck.position.Y);
            Assert.Equal(Heading.SOUTH, testTruck.heading);
        }

        [Fact]
        public void testDriveCounterClockWiseSquare()
        {
            Car testTruck = new MonsterTruck(Heading.NORTH, new Position(0, 0));

            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            Assert.Equal(0, testTruck.position.X);
            Assert.Equal(3, testTruck.position.Y);
            Assert.Equal(Heading.NORTH, testTruck.heading);

            testTruck.executeCommand(Command.RIGHT);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            Assert.Equal(3, testTruck.position.X);
            Assert.Equal(3, testTruck.position.Y);
            Assert.Equal(Heading.EAST, testTruck.heading);

            testTruck.executeCommand(Command.RIGHT);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            Assert.Equal(3, testTruck.position.X);
            Assert.Equal(0, testTruck.position.Y);
            Assert.Equal(Heading.SOUTH, testTruck.heading);

            testTruck.executeCommand(Command.RIGHT);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            testTruck.executeCommand(Command.FORWARD);
            Assert.Equal(0, testTruck.position.X);
            Assert.Equal(0, testTruck.position.Y);
            Assert.Equal(Heading.WEST, testTruck.heading);
        }
    }
}