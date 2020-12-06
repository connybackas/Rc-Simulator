
namespace RcSimulator.Implementation.RcCar
{
    /// <summary>
    /// Position struct used for specifying a position in a two dimensional space
    /// </summary>
    public struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() => $"({X}, {Y})";

    }
}