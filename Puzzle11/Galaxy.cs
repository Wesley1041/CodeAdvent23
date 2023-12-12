using Helpers;

namespace Puzzle11;

public class Galaxy
{
    public Position Position { get; set; }

    public Galaxy(Position position)
    {
        Position = position;
    }

    public int GetDistance(Galaxy other)
    {
        return Math.Abs(Position.X - other.Position.X) + Math.Abs(Position.Y - other.Position.Y);
    }
}