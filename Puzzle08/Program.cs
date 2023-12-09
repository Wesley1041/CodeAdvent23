using Puzzle08;

ParseResult Arrange()
{
    // Get directions
    var directions = Parser.ParseDirections();

    Console.ReadLine();

    var locations = Parser.ParseLocations();

    return new ParseResult(locations, directions);
}

long LCM(long[] numbers)
{
    return numbers.Aggregate(lcm);
}

long lcm(long a, long b)
{
    return Math.Abs(a * b) / GCD(a, b);
}

long GCD(long a, long b)
{
    return b == 0 ? a : GCD(b, a % b);
}

void Execute()
{
    var input = Arrange();

    var executor = new PartTwo(input.Locations, input.Directions);

    // Get start locations
    var startLocations = input.Locations
        .Where(p => p.Key.EndsWith('A'))
        .Select(p => p.Value)
        .ToList();

    var steps = startLocations.Select(l => (long)executor.DoSteps(l)).ToArray();

    var sum = LCM(steps);

    Console.WriteLine(sum);
}

Execute();