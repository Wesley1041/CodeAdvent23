namespace Puzzle08
{
    public static class Parser
    {
        public static bool[] ParseDirections()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input)) throw new ArgumentException("No valid input");

            return input.Select(c => c == 'L').ToArray();
        }

        public static Dictionary<string, Location> ParseLocations()
        {
            // Parse lines
            var lines = new List<string>();
            while (true)
            {
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) break;

                lines.Add(input);
            }

            var locations = new Dictionary<string, Location>();

            // Get locations
            foreach (var line in lines)
            {
                var location = ParseLocation(line);
                locations.Add(location.Name, location);
            }

            // Get location directions
            foreach (var line in lines)
            {
                var content = line.Split(" = ");
                var name = content[0];

                var otherLocations = content[1].Split(", ");
                var left = otherLocations[0].Substring(1);
                var right = otherLocations[1].Substring(0, otherLocations[1].Length - 1);

                locations[name].Left = locations[left];
                locations[name].Right = locations[right];
            }

            return locations;
        }

        private static Location ParseLocation(string input)
        {
            var content = input.Split(" = ");
            var name = content[0];

            return new Location(name);
        }
    }
}
