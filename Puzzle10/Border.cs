namespace Puzzle10
{
    public class Border
    {
        public Position Position { get; set; }
        public bool IsOpen { get; set; }

        public Border(Position position, bool isOpen)
        {
            Position = position;
            IsOpen = isOpen;
        }
    }
}
