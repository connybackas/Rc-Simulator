
namespace RcSimulator.Implementation.RcCar
{
    /// <summary>
    /// Abstract Car class. All different Rc cars should extend this class
    /// </summary>
    public abstract class Car
    {
        public Heading heading { get; set; }
        public Position position { get; set; }

        /// <summary>
        /// Rotates the car 90 degrees clockwise
        /// </summary>
        private void turnRight()
        {
            this.heading = HeadingUtils.nextValue(this.heading);
        }

        /// <summary>
        /// Rotates the car 90 degrees counterclockwise
        /// </summary>
        private void turnLeft()
        {
            this.heading = HeadingUtils.previousValue(this.heading);
        }

        /// <summary>
        /// Moves the car one step forward or one step back 
        /// </summary>
        /// <param name="movement">Forward or Back</param>
        private void moveCar(Command movement)
        {
            int xPos = this.position.X;
            int yPos = this.position.Y;

            // Determine which position to change based on current heading and given movement command.
            switch (this.heading)
            {
                case Heading.NORTH:
                    yPos += movement.Equals(Command.FORWARD) ? +1 : -1;
                    break;
                case Heading.EAST:
                    xPos += movement.Equals(Command.FORWARD) ? +1 : -1;
                    break;
                case Heading.SOUTH:
                    yPos += movement.Equals(Command.FORWARD) ? -1 : +1;
                    break;
                case Heading.WEST:
                    xPos += movement.Equals(Command.FORWARD) ? -1 : +1;
                    break;
            }

            this.position = new Position(xPos, yPos);
        }

                /// <summary>
        /// Executes the command given
        /// </summary>
        /// <param name="carCommand">Forward, Back, Left or Rigth</param>
        public void executeCommand(Command carCommand)
        {
            switch (carCommand)
            {
                case Command.FORWARD:
                case Command.BACK:
                    this.moveCar(carCommand);
                    break;

                case Command.RIGHT:
                    this.turnRight();
                    break;

                case Command.LEFT:
                    this.turnLeft();
                    break;
            }
        }
    }
}