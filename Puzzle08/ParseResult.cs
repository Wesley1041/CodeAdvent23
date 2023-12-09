namespace Puzzle08
{
    public class ParseResult
    {
        public Dictionary<string, Location> Locations { get; set; }
        public bool[] Directions { get; set; }

        public ParseResult(Dictionary<string, Location> locations, bool[] directions)
        {
            Locations = locations;
            Directions = directions;
        }
    }
}
