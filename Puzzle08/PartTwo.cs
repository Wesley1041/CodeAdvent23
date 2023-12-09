namespace Puzzle08
{
    public class PartTwo
    {
        public Dictionary<string, Location> Locations { get; set; }
        public bool[] Directions { get; set; }

        public PartTwo(Dictionary<string, Location> locations, bool[] directions)
        {
            Locations = locations;
            Directions = directions;
        }

        public int DoSteps(Location currentLocation)
        {
            // Do steps
            int steps = 0;

            while (true)
            {
                foreach (var direction in Directions)
                {
                    currentLocation = DoStep(currentLocation, direction);
                    steps++;

                    // Check locations
                    if (currentLocation.Name.EndsWith('Z')) return steps;
                }
            }
        }

        public long DoMultipleStepsBruteForce()
        {
            // Get starting points
            var currentLocations = new List<Location>();

            foreach (var pair in Locations)
            {
                if (pair.Key.EndsWith('A'))
                {
                    currentLocations.Add(pair.Value);
                }
            }

            // Do steps
            long steps = 0;

            while (true)
            {
                foreach (var direction in Directions)
                {
                    Parallel.For(0, currentLocations.Count, i =>
                    {
                        currentLocations[i] = DoStep(currentLocations[i], direction);
                    });
                    steps++;

                    // Check locations
                    if (AreAllEndLocations(currentLocations)) return steps;
                }
            }
        }

        private LoopResult StepsUntilResult(Location startLocation)
        {
            var firstNextLocation = DoStep(startLocation, Directions[0]);
            var currentLocation = firstNextLocation;
            var finishSteps = new List<int>();

            var steps = -1;
            while (true)
            {
                foreach (var direction in Directions)
                {
                    if (currentLocation == null) throw new Exception("Location is null");

                    currentLocation = DoStep(currentLocation, direction);

                    if (currentLocation.Name.EndsWith('Z'))
                    {
                        finishSteps.Add(steps);
                    }

                    if (currentLocation == firstNextLocation && steps > 0)
                    {
                        return new LoopResult(steps, finishSteps);
                    }
                }
            }
        }

        private Location DoStep(Location location, bool isLeft)
        {
            if (location.Left == null || location.Right == null) throw new Exception("Location is null");

            return isLeft ? location.Left : location.Right;
        }

        private bool AreAllEndLocations(List<Location> locations)
        {
            var count = 0;
            foreach (var location in locations)
            {
                if (!location.Name.EndsWith('Z')) return false;
            }

            return true;
        }
    }
}
