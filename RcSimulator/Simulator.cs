using System;
using System.Text.RegularExpressions;
using RcSimulator.Implementation.RcCar;

namespace RcSimulator.Implementation
{
    /// <summary>
    /// Simulator for testing of Rc Cars
    /// </summary>
    public class Simulator
    {
        // Maximal number of digits allowed
        private const int MAX_DIGITS = 2;

        // Maximal number of commands allowed
        private const int MAX_COMMANDS = 50;

        // Room size pattern used for parsing user input. Accepts two integers seperated by a whitespace
        private static Regex ROOM_SIZE_PATTERN = new Regex("^\\d{1," + MAX_DIGITS + "}\\s\\d{1," + MAX_DIGITS + "}$");

        // Car position and heading pattern used for parsing user input
        // Accepts two integers and one of following characters (N,E,S,W), seperated by a whitespace
        private static Regex CAR_POS_AND_HEADING_PATTERN = new Regex("^\\d{1," + MAX_DIGITS + "}\\s\\d{1," + MAX_DIGITS + "}\\s[NESW]{1}$");

        // Car command series pattern used for parsing user input.
        // Accepts one or several of following characters (F,B,R,L) specified as a series
        private static Regex CAR_COMMANDS_PATTERN = new Regex("^[FBRL]{1," + MAX_COMMANDS + "}$");

        private int roomWidth;
        private int roomLength;
        private Car car;
        private Char[] commandInputs;

        public Simulator(Car car)
        {
            this.car = car;
        }

        /// <summary>
        /// Asks user to enter room size and saves entered values
        /// </summary>
        public void promptSimulatorRoomSize()
        {
            Console.Write("Enter simulation room size: ");
            string input = Console.ReadLine().ToUpper();

            // If input wasn't valid, print error message and do a recursive call.
            if (!ROOM_SIZE_PATTERN.IsMatch(input))
            {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("Room size is entered with two integers seperated by a whitespace. E.g. (4 5)\n");
                promptSimulatorRoomSize();
                return;
            }

            // Save values
            var splittedInput = input.Split(' ', 2);
            this.roomWidth = int.Parse(splittedInput[0]);
            this.roomLength = int.Parse(splittedInput[1]);
            Console.WriteLine($"Room size is set to: ({this.roomWidth}, {this.roomLength})\n");
        }

        /// <summary>
        /// Asks user to enter start position and heading of the car and saves entered values
        /// </summary>
        public void promptStartPosAndCarHeading()
        {
            Console.Write("Enter start position and heading of RC car: ");
            string input = Console.ReadLine().ToUpper();

            // If input wasn't valid, print error message and do a recursive call.
            if (!CAR_POS_AND_HEADING_PATTERN.IsMatch(input))
            {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("Start position and heading is entered by specifying two integers " 
                + "and one of following characters (N,E,S,W) seperated by whitespaces. E.g. (1 1 N)\n");
                promptStartPosAndCarHeading();
                return;
            }

            // Parse input
            var splittedInput = input.Split(' ', 3);
            int horizontalPos = int.Parse(splittedInput[0]);
            int verticalPos = int.Parse(splittedInput[1]);
            char headingCommand = Char.Parse(splittedInput[2]);

            // If entered car position was outside simulator room, print error message and do a recursive call
            if (horizontalPos > this.roomWidth || verticalPos > this.roomLength)
            {
                Console.WriteLine("Start position of car must be inside of the simulator room!\n");
                promptStartPosAndCarHeading();
                return;
            }

            // Save values 
            this.car.heading = HeadingUtils.getHeadingByCommand(headingCommand);
            this.car.position = new Position(horizontalPos, verticalPos);
            Console.WriteLine($"Initialized car position: {car.position} and heading {car.heading.ToString().ToLower()}\n");
        }

        /// <summary>
        /// Asks the user about the commands to execute and saves entered command series
        /// </summary>
        public void promptCarMovementCommandSeries()
        {
            Console.Write("Enter car movement command series: ");
            string input = Console.ReadLine().ToUpper();

            // If input wasn't valid, print error message and do a recursive call.
            if (!CAR_COMMANDS_PATTERN.IsMatch(input))
            {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("Commands is specifed with one or several of following" 
                + " characters (F,B,R,L) entered as a series. E.g. (FRFFLRRBB)\n");
                promptCarMovementCommandSeries();
                return;
            }

            // Save values
            this.commandInputs = input.ToCharArray();
        }

        /// <summary>
        /// Starts the simulation
        /// </summary>
        public void startSimulation()
        {

            Console.WriteLine("Starting simulation...\n");
            bool horizontalCarPosOk = false;
            bool verticalCarPosOK = false;
            // Foreach command in the command series...
            foreach (var command in commandInputs)
            {
                // Execute command on the car
                car.executeCommand((Command)command);

                // Check if horitzontal posistion is still ok
                horizontalCarPosOk = car.position.X >= 0 && car.position.X <= roomWidth;
                // Check if vertical position is still ok 
                verticalCarPosOK = car.position.Y >= 0 && car.position.Y <= roomLength;

                // If horizontal or vertical car position isn't ok...
                if (!(horizontalCarPosOk && verticalCarPosOK))
                {
                    // Fetch the collided wall heading
                    Heading collidedWall = getCollidedWall();
                    // Explain error to user
                    Console.WriteLine($"Simulation unsuccessful! Rc car drove into the {collidedWall.ToString().ToLower()} wall.");
                    // Exit function
                    return;
                }
            }

            Console.WriteLine("Simulation was successful! "
            + $"Rc car stopped at position: {this.car.position} with heading: {this.car.heading.ToString().ToLower()}");
        }

        /// <summary>
        /// Fetches the heading of the wall that the car collided with
        /// </summary>
        /// <returns>The heading of the collided wall</returns>
        private Heading getCollidedWall()
        {
            if (car.position.X > roomWidth)
            {
                return Heading.EAST;
            }
            else if (car.position.X < 0)
            {
                return Heading.WEST;
            }
            else if (car.position.Y > roomLength)
            {
                return Heading.NORTH;
            }
            else
            {
                return Heading.SOUTH;
            }
        }
    }
}