namespace Puzzle08
{
    public class Location
    {
        public string Name { get; }
        public Location? Left { get; set; }
        public Location? Right { get; set; }

        public Location(string name)
        {
            Name = name;
        }
    }
}
