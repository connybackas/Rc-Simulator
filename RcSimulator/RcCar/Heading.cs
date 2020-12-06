using System.Collections.Generic;

namespace RcSimulator.Implementation.RcCar
{
    /// <summary>
    /// Enum used to specify heading
    /// </summary>
    public enum Heading
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    /// <summary>
    /// Utility class for the Heading enum
    /// </summary>
    public static class HeadingUtils
    {
        /// <summary>
        /// Dictionary used for looking up heading value given a heading command
        /// </summary>
        /// <value></value>
        private static Dictionary<char, Heading> headings = new Dictionary<char, Heading> {
             { 'N', Heading.NORTH }, { 'E', Heading.EAST }, { 'S', Heading.SOUTH }, { 'W', Heading.WEST }
        };

        /// <summary>
        /// Fetches heading value based on the given command
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Heading enumeration value</returns>
        public static Heading getHeadingByCommand(char command)
        {
            return headings.GetValueOrDefault(command);
        }

        /// <summary>
        /// Fetches the next heading value based on the given heading
        /// </summary>
        /// <param name="heading"></param>
        /// <returns>The next heading clockwise</returns>
        public static Heading nextValue(Heading heading)
        {
            return heading.Equals(Heading.WEST) ? Heading.NORTH : ++heading;
        }

        /// <summary>
        /// Fetches the previous heading value based on the given heading
        /// </summary>
        /// <param name="heading"></param>
        /// <returns>The previous heading counterclockwise</returns>
        public static Heading previousValue(Heading heading)
        {
            return heading.Equals(Heading.NORTH) ? Heading.WEST : --heading;
        }
    }
}